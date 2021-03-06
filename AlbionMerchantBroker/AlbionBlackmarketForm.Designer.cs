﻿using System.Windows.Forms;

namespace AlbionBlackMarketForms
{
    partial class AlbionBlackmarketForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.item_list_view = new System.Windows.Forms.ListView();
            this.tier = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.item_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.point = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.quality = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.caerleon_price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.backmarket_price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.income = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stale_time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.remove = new System.Windows.Forms.ToolStripMenuItem();
            this.copy = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshButton = new System.Windows.Forms.Button();
            this.buy_from_market = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // item_list_view
            // 
            this.item_list_view.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.item_list_view.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.item_list_view.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.tier,
            this.item_name,
            this.point,
            this.quality,
            this.caerleon_price,
            this.backmarket_price,
            this.income,
            this.stale_time});
            this.item_list_view.ContextMenuStrip = this.contextMenuStrip1;
            this.item_list_view.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_list_view.FullRowSelect = true;
            this.item_list_view.HideSelection = false;
            this.item_list_view.Location = new System.Drawing.Point(160, 12);
            this.item_list_view.MultiSelect = false;
            this.item_list_view.Name = "item_list_view";
            this.item_list_view.Size = new System.Drawing.Size(1008, 642);
            this.item_list_view.TabIndex = 0;
            this.item_list_view.UseCompatibleStateImageBehavior = false;
            this.item_list_view.View = System.Windows.Forms.View.Details;
            this.item_list_view.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.Item_list_view_ItemSelectionChanged);
            // 
            // tier
            // 
            this.tier.Text = "Tier";
            this.tier.Width = 50;
            // 
            // item_name
            // 
            this.item_name.Text = "Item";
            this.item_name.Width = 250;
            // 
            // point
            // 
            this.point.Text = "Enchantment Point";
            this.point.Width = 110;
            // 
            // quality
            // 
            this.quality.Text = "Quality";
            this.quality.Width = 150;
            // 
            // caerleon_price
            // 
            this.caerleon_price.Text = "Caerleon Price";
            this.caerleon_price.Width = 100;
            // 
            // backmarket_price
            // 
            this.backmarket_price.Text = "Back Market Price";
            this.backmarket_price.Width = 100;
            // 
            // income
            // 
            this.income.Text = "Income";
            this.income.Width = 100;
            // 
            // stale_time
            // 
            this.stale_time.Text = "Stale Time";
            this.stale_time.Width = 100;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.remove,
            this.copy});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(170, 48);
            this.contextMenuStrip1.Click += new System.EventHandler(this.ContextMenuStrip1_Click);
            // 
            // remove
            // 
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(169, 22);
            this.remove.Text = "Remove";
            this.remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // copy
            // 
            this.copy.Name = "copy";
            this.copy.Size = new System.Drawing.Size(169, 22);
            this.copy.Text = "Copy to clipboard";
            this.copy.Click += new System.EventHandler(this.Copy_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(12, 12);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(142, 37);
            this.refreshButton.TabIndex = 1;
            this.refreshButton.Text = "refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // buy_from_market
            // 
            this.buy_from_market.FormattingEnabled = true;
            this.buy_from_market.Items.AddRange(new object[] {
            "Black Market",
            "Bridgewatch",
            "Caerleon",
            "Fort Sterling",
            "Lymhurst",
            "Martlock",
            "Morganas Rest",
            "Steppe Cross",
            "Thetford"});
            this.buy_from_market.Location = new System.Drawing.Point(12, 115);
            this.buy_from_market.Name = "buy_from_market";
            this.buy_from_market.Size = new System.Drawing.Size(142, 21);
            this.buy_from_market.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.HideSelection = false;
            this.textBox2.Location = new System.Drawing.Point(13, 89);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(141, 20);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "Buy From Market";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Resources",
            "Equipment",
            "Other",
            "All"});
            this.comboBox3.Location = new System.Drawing.Point(13, 243);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(142, 21);
            this.comboBox3.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.HideSelection = false;
            this.textBox1.Location = new System.Drawing.Point(14, 155);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(141, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "Sell To Market";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.HideSelection = false;
            this.textBox3.Location = new System.Drawing.Point(14, 217);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(141, 20);
            this.textBox3.TabIndex = 9;
            this.textBox3.Text = "Items To Query";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Black Market",
            "Bridgewatch",
            "Caerleon",
            "Fort Sterling",
            "Lymhurst",
            "Martlock",
            "Morganas Rest",
            "Steppe Cross",
            "Thetford"});
            this.comboBox1.Location = new System.Drawing.Point(13, 181);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(142, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // AlbionBlackmarketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1180, 666);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.buy_from_market);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.item_list_view);
            this.Name = "AlbionBlackmarketForm";
            this.Text = "AlbionBlackmarketForm";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView item_list_view;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ColumnHeader item_name;
        private System.Windows.Forms.ColumnHeader caerleon_price;
        private System.Windows.Forms.ColumnHeader backmarket_price;
        private System.Windows.Forms.ColumnHeader income;
        private System.Windows.Forms.ColumnHeader stale_time;
        private System.Windows.Forms.ColumnHeader tier;
        private System.Windows.Forms.ColumnHeader point;
        private System.Windows.Forms.ColumnHeader quality;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem remove;
        private ToolStripMenuItem copy;
        private ComboBox buy_from_market;
        private TextBox textBox2;
        private ComboBox comboBox3;
        private TextBox textBox1;
        private TextBox textBox3;
        private ComboBox comboBox1;
    }
}

