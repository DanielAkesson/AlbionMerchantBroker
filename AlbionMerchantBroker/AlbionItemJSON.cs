using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionBlackMarket
{
    struct AlbionItemEntryJSON
    {
        public string UniqueName;
        public Dictionary<string, string> LocalizedNames;
        public Dictionary<string, string> LocalizedDescriptions;
    }
    struct AlbionItemLocalizedNamesJSON
    {
        public string EN;
    }

    struct AlbionItemAPIResponseBlackMarketJSON
    {
        public int buy_price_max;
        public string buy_price_max_date;
    }
    struct AlbionItemAPIResponseCaerleonJSON
    {
        public int sell_price_min;
        public string sell_price_min_date;
    }

    struct AlbionItemAPIDeltaEntry
    {
        public string blackMarketEntry;
        public string caerleonEntry;
        public string caerleonTier;
        public string caerleonPoint;
        public string caerleonQuality;
        public int sell_price_caerleon;
        public int buy_price_blackmarket;
        public int delta;
        public DateTime blackMarketStaleTime;
        public DateTime caerleonStaleTime;
        public DateTime maxStaleTime;
    }
}
