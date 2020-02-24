using AlbionBlackMarket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlbionBlackMarketForms
{
    public partial class AlbionBlackmarketForm : Form
    {
        public AlbionBlackmarketForm()
        {
            InitializeComponent();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            lock (Program.deltaList)
            {
                Program.deltaList.Sort((x, y) => (int)DateTime.UtcNow.Subtract(x.blackMarketStaleTime).TotalSeconds - (int)DateTime.UtcNow.Subtract(y.blackMarketStaleTime).TotalSeconds);
                item_list_view.Items.Clear();
                foreach (AlbionItemAPIDeltaEntry entry in Program.deltaList)
                {
                    if (entry.delta <= 0)
                        continue;

                    ListViewItem item = new ListViewItem(entry.caerleonTier);
                    item.SubItems.Add(entry.caerleonEntry);
                    item.SubItems.Add(entry.caerleonPoint);
                    item.SubItems.Add(entry.caerleonQuality);
                    item.SubItems.Add(entry.sell_price_caerleon.ToString("0,0", CultureInfo.InvariantCulture));
                    item.SubItems.Add(entry.buy_price_blackmarket.ToString("0,0", CultureInfo.InvariantCulture));
                    item.SubItems.Add(entry.delta.ToString("0,0", CultureInfo.InvariantCulture));
                    item.SubItems.Add(((int)DateTime.UtcNow.Subtract(entry.blackMarketStaleTime).TotalMinutes).ToString());

                    //Colors!
                    //Name
                    item.SubItems[0].ForeColor = Color.FromArgb(255, 255, 255);
                    item.SubItems[1].ForeColor = Color.FromArgb(255, 255,150);
                    item.SubItems[2].ForeColor = Color.FromArgb(255, 150, 255);
                    item.SubItems[3].ForeColor = Color.FromArgb(200, 200, 200);
                    //Money

                    item.SubItems[4].ForeColor = Color.FromArgb(255, 100, 100);
                    item.SubItems[5].ForeColor = Color.FromArgb(100, 255, 100);
                    //Income!
                    double incomeFactor = entry.delta / 5000.0d;
                    incomeFactor = incomeFactor > 1.0d ? 1.0d : incomeFactor;
                    item.SubItems[6].ForeColor = Color.FromArgb(255, (int)(incomeFactor * 255), 0);
                    //Time!
                    double timeFactor = DateTime.UtcNow.Subtract(entry.blackMarketStaleTime).TotalMinutes / 240.0d;
                    timeFactor = timeFactor > 1.0d ? 1.0d : timeFactor;
                    item.SubItems[7].ForeColor = Color.FromArgb(255, (int)((1.0d - timeFactor) * 255), (int)((1.0d-timeFactor) * 255));
                    item.UseItemStyleForSubItems = false;
                    item_list_view.Items.Add(item);
                }
            }
        }

        private void Item_list_view_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if(item_list_view.SelectedItems != null && item_list_view.SelectedItems.Count > 0)
                Clipboard.SetText(item_list_view.SelectedItems[0].SubItems[1].Text);
        }

        private void ContextMenuStrip1_Click(object sender, EventArgs e)
        {

        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if (item_list_view.SelectedItems != null && item_list_view.SelectedItems.Count > 0)
            {
                int index = Program.deltaList.FindIndex( x => { return
                    x.caerleonEntry == item_list_view.SelectedItems[0].SubItems[1].Text && 
                    x.caerleonPoint == item_list_view.SelectedItems[0].SubItems[2].Text &&
                    x.caerleonQuality == item_list_view.SelectedItems[0].SubItems[3].Text;
                });
                lock (Program.deltaList)
                {
                    Program.deltaList.RemoveAt(index);
                }

                RefreshButton_Click(null, null);
            }
        }

        private void Copy_Click(object sender, EventArgs e)
        {
                
            if (item_list_view.SelectedItems != null && item_list_view.SelectedItems.Count > 0)
                Clipboard.SetText(item_list_view.SelectedItems[0].SubItems[1].Text);
        }
    }
}
