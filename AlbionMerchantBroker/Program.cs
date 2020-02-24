using AlbionBlackMarket;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlbionBlackMarketForms
{
    static class Program
    {
        const string api = "https://www.albion-online-data.com/api/v2/stats/Prices/ITEM_NAME?locations=LOCATIONNAME";
        public static List<AlbionItemAPIDeltaEntry> deltaList = new List<AlbionItemAPIDeltaEntry>();
        static List<AlbionItemEntryJSON> albionItems = new List<AlbionItemEntryJSON>();
        static int searchedAmount = 0;

        [STAThread]
        static void Main()
        {
            string input = File.ReadAllText("Resources/AlbionEquipments.json", Encoding.UTF8);
            albionItems = JsonConvert.DeserializeObject<List<AlbionItemEntryJSON>>(input);
            Random rand = new Random();
            albionItems.Sort((x, y) => rand.Next(0, 100) - rand.Next(0, 100));


            //input = File.ReadAllText("Resources/AlbionItems.json", Encoding.UTF8);
            //albionItems = JsonConvert.DeserializeObject<List<AlbionItemEntryJSON>>(input);
            //for(int i=0; i< albionItems.Count; i++)
            //{
            //    if (albionItems[i].LocalizedNames != null && albionItems[i].LocalizedNames.ContainsKey("EN-US"))
            //        Console.Write(albionItems[i].LocalizedNames["EN-US"]);
            //    if (albionItems[i].LocalizedDescriptions != null && albionItems[i].LocalizedDescriptions.ContainsKey("EN-US"))
            //        Console.Write(albionItems[i].LocalizedDescriptions["EN-US"]);
            //    Console.WriteLine(" index: " + i);
            //}

            //Start all query threads
            foreach (AlbionItemEntryJSON entry in albionItems)
                ThreadPool.QueueUserWorkItem((x) => APIPullAndCompareAlbionItem(entry));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AlbionBlackmarketForm());
        }

        //Api Querry thread
        public static void APIPullAndCompareAlbionItem(AlbionItemEntryJSON entry)
        {
            //Query API about items!
            string query = api.Replace("ITEM_NAME", entry.UniqueName).Replace("LOCATIONNAME", "Black Market");
            AlbionItemAPIResponseBlackMarketJSON[] blackMarket = JsonConvert.DeserializeObject<AlbionItemAPIResponseBlackMarketJSON[]>(CompressedHttpGet(query));
            query = api.Replace("ITEM_NAME", entry.UniqueName).Replace("LOCATIONNAME", "Caerleon");
            AlbionItemAPIResponseCaerleonJSON[] caerleon = JsonConvert.DeserializeObject<AlbionItemAPIResponseCaerleonJSON[]>(CompressedHttpGet(query));

            //Look for best sell combination for quality
            for (int i = 0; i < blackMarket.Length; i++)
            {
                AlbionItemAPIDeltaEntry delta = new AlbionItemAPIDeltaEntry();
                delta.buy_price_blackmarket = blackMarket[i].buy_price_max;

                //Find quality that sells for the least but is higher than or equal to i
                int bestIndex = i;
                int bestprice = int.MaxValue;
                for (int j = i; j < caerleon.Length; j++)
                {
                    if (caerleon[j].sell_price_min > 0 && caerleon[j].sell_price_min < bestprice)
                    {
                        bestprice = caerleon[j].sell_price_min;
                        bestIndex = j;
                    }
                }

                //Escape if too good to be true!
                if (bestIndex >= caerleon.Length || delta.buy_price_blackmarket <= 0 || caerleon[bestIndex].sell_price_min <= 0)
                    continue;

                delta.caerleonStaleTime = DateTime.Parse(caerleon[bestIndex].sell_price_min_date, CultureInfo.CreateSpecificCulture("en-US"));
                delta.blackMarketStaleTime = DateTime.Parse(caerleon[bestIndex].sell_price_min_date, CultureInfo.CreateSpecificCulture("en-US"));
                delta.maxStaleTime = DateTime.Compare(delta.caerleonStaleTime, delta.blackMarketStaleTime) > 0 ? delta.caerleonStaleTime : delta.blackMarketStaleTime;
                delta.sell_price_caerleon = caerleon[bestIndex].sell_price_min;
                delta.delta = delta.buy_price_blackmarket - delta.sell_price_caerleon;
                delta.caerleonEntry = entry.LocalizedNames["EN-US"];
                delta.caerleonPoint =GetEnchantLevelForUniq(entry.UniqueName);
                delta.caerleonQuality = GetQualityName(bestIndex);
                delta.caerleonTier = GetTierLevelForUniq(entry.UniqueName);
                delta.blackMarketEntry = GetTierLevelForUniq(entry.UniqueName) + " " + entry.LocalizedNames["EN-US"] + " " + GetEnchantLevelForUniq(entry.UniqueName) + " Quality " + i;

                lock (deltaList)
                {
                    deltaList.Add(delta);
                }
            }
            //Todo: create new lock for this!
            lock (deltaList)
            {
                searchedAmount++;
            }
        }
        public static string GetTierLevelForUniq(string item)
        {
            if (item.Contains("T1_"))
                return "Tier 1";
            if (item.Contains("T2_"))
                return "Tier 2";
            if (item.Contains("T3_"))
                return "Tier 3";
            if (item.Contains("T4_"))
                return "Tier 4";
            if (item.Contains("T5_"))
                return "Tier 5";
            if (item.Contains("T6_"))
                return "Tier 6";
            if (item.Contains("T7_"))
                return "Tier 7";
            if (item.Contains("T8_"))
                return "Tier 8";
            if (item.Contains("T9_"))
                return "Tier 9";

            return "Unknown Tier";
        }
        public static string GetEnchantLevelForUniq(string item)
        {
            if (item.Contains("@1"))
                return "Point 1";
            if (item.Contains("@2"))
                return "Point 2";
            if (item.Contains("@3"))
                return "Point 3";

            return "Point 0";
        }
        public static string GetQualityName(int quality)
        {
            switch (quality)
            {
                case 0:
                    return "Normal (0)"; 
                case 1:
                    return "Good (1)";
                case 2:
                    return "Outstanding (2)";
                case 3:
                    return "Excelent (3)";
                case 4:
                    return "Masterwork (4)";
            }
            return "Unkonwn";
        }
        public static string CompressedHttpGet(string URI)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            string html = "";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream)) { html = reader.ReadToEnd(); }
            return html;
        }
    }
}
