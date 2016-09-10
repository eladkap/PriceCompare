namespace FinalLab
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.storesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.priceFullToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myCartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.priceCompareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadCartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lbl_hello = new System.Windows.Forms.Label();
            this.txt_searchItemName = new System.Windows.Forms.TextBox();
            this.lbl_username = new System.Windows.Forms.Label();
            this.comboBox_chain = new System.Windows.Forms.ComboBox();
            this.comboBox_store = new System.Windows.Forms.ComboBox();
            this.btn_searchItem = new System.Windows.Forms.Button();
            this.flowLayoutPanel_items = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_chain = new System.Windows.Forms.Label();
            this.pictureBox_chainLogo = new System.Windows.Forms.PictureBox();
            this.lbl_resultsNum = new System.Windows.Forms.Label();
            this.lbl_chooseChainStore = new System.Windows.Forms.Label();
            this.btn_viewCart = new System.Windows.Forms.Button();
            this.lbl_cartSize = new System.Windows.Forms.Label();
            this.btn_comparePrices = new System.Windows.Forms.Button();
            this.comboBox_city = new System.Windows.Forms.ComboBox();
            this.lbl_chooseCity = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_chainLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.catalogToolStripMenuItem,
            this.cartToolStripMenuItem,
            this.accountToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1362, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // catalogToolStripMenuItem
            // 
            this.catalogToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem});
            this.catalogToolStripMenuItem.Name = "catalogToolStripMenuItem";
            this.catalogToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.catalogToolStripMenuItem.Text = "Catalog";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.storesToolStripMenuItem,
            this.priceFullToolStripMenuItem});
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.updateToolStripMenuItem.Text = "Update";
            // 
            // storesToolStripMenuItem
            // 
            this.storesToolStripMenuItem.Name = "storesToolStripMenuItem";
            this.storesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.storesToolStripMenuItem.Text = "Stores";
            this.storesToolStripMenuItem.Click += new System.EventHandler(this.storesToolStripMenuItem_Click);
            // 
            // priceFullToolStripMenuItem
            // 
            this.priceFullToolStripMenuItem.Name = "priceFullToolStripMenuItem";
            this.priceFullToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.priceFullToolStripMenuItem.Text = "PriceFull";
            this.priceFullToolStripMenuItem.Click += new System.EventHandler(this.priceFullToolStripMenuItem_Click);
            // 
            // cartToolStripMenuItem
            // 
            this.cartToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.myCartToolStripMenuItem,
            this.priceCompareToolStripMenuItem,
            this.loadCartToolStripMenuItem});
            this.cartToolStripMenuItem.Name = "cartToolStripMenuItem";
            this.cartToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.cartToolStripMenuItem.Text = "Cart";
            // 
            // myCartToolStripMenuItem
            // 
            this.myCartToolStripMenuItem.Name = "myCartToolStripMenuItem";
            this.myCartToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.myCartToolStripMenuItem.Text = "My Cart";
            this.myCartToolStripMenuItem.Click += new System.EventHandler(this.myCartToolStripMenuItem_Click);
            // 
            // priceCompareToolStripMenuItem
            // 
            this.priceCompareToolStripMenuItem.Name = "priceCompareToolStripMenuItem";
            this.priceCompareToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.priceCompareToolStripMenuItem.Text = "Compare Prices";
            // 
            // loadCartToolStripMenuItem
            // 
            this.loadCartToolStripMenuItem.Name = "loadCartToolStripMenuItem";
            this.loadCartToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.loadCartToolStripMenuItem.Text = "Load Cart";
            this.loadCartToolStripMenuItem.Click += new System.EventHandler(this.loadCartToolStripMenuItem_Click);
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registerToolStripMenuItem,
            this.loginToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.accountToolStripMenuItem.Text = "Account";
            // 
            // registerToolStripMenuItem
            // 
            this.registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            this.registerToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.registerToolStripMenuItem.Text = "Register";
            this.registerToolStripMenuItem.Click += new System.EventHandler(this.registerToolStripMenuItem_Click);
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lbl_hello
            // 
            this.lbl_hello.AutoSize = true;
            this.lbl_hello.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_hello.Location = new System.Drawing.Point(12, 34);
            this.lbl_hello.Name = "lbl_hello";
            this.lbl_hello.Size = new System.Drawing.Size(44, 17);
            this.lbl_hello.TabIndex = 3;
            this.lbl_hello.Text = "Hello,";
            // 
            // txt_searchItemName
            // 
            this.txt_searchItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_searchItemName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_searchItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_searchItemName.Location = new System.Drawing.Point(402, 212);
            this.txt_searchItemName.Name = "txt_searchItemName";
            this.txt_searchItemName.Size = new System.Drawing.Size(242, 23);
            this.txt_searchItemName.TabIndex = 5;
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_username.Location = new System.Drawing.Point(62, 34);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(46, 17);
            this.lbl_username.TabIndex = 8;
            this.lbl_username.Text = "label1";
            // 
            // comboBox_chain
            // 
            this.comboBox_chain.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox_chain.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_chain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.comboBox_chain.FormattingEnabled = true;
            this.comboBox_chain.Location = new System.Drawing.Point(402, 163);
            this.comboBox_chain.Name = "comboBox_chain";
            this.comboBox_chain.Size = new System.Drawing.Size(242, 24);
            this.comboBox_chain.TabIndex = 10;
            this.comboBox_chain.SelectedIndexChanged += new System.EventHandler(this.comboBox_chain_SelectedIndexChanged);
            // 
            // comboBox_store
            // 
            this.comboBox_store.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox_store.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_store.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.comboBox_store.FormattingEnabled = true;
            this.comboBox_store.Location = new System.Drawing.Point(676, 163);
            this.comboBox_store.Name = "comboBox_store";
            this.comboBox_store.Size = new System.Drawing.Size(242, 24);
            this.comboBox_store.TabIndex = 10;
            this.comboBox_store.SelectedIndexChanged += new System.EventHandler(this.comboBox_store_SelectedIndexChanged);
            // 
            // btn_searchItem
            // 
            this.btn_searchItem.Enabled = false;
            this.btn_searchItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_searchItem.Location = new System.Drawing.Point(276, 212);
            this.btn_searchItem.Name = "btn_searchItem";
            this.btn_searchItem.Size = new System.Drawing.Size(75, 23);
            this.btn_searchItem.TabIndex = 11;
            this.btn_searchItem.Text = "Search";
            this.btn_searchItem.UseVisualStyleBackColor = true;
            this.btn_searchItem.Click += new System.EventHandler(this.btn_searchItem_Click);
            // 
            // flowLayoutPanel_items
            // 
            this.flowLayoutPanel_items.Location = new System.Drawing.Point(223, 308);
            this.flowLayoutPanel_items.Margin = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel_items.Name = "flowLayoutPanel_items";
            this.flowLayoutPanel_items.Size = new System.Drawing.Size(300, 50);
            this.flowLayoutPanel_items.TabIndex = 12;
            this.flowLayoutPanel_items.WrapContents = false;
            // 
            // lbl_chain
            // 
            this.lbl_chain.AutoSize = true;
            this.lbl_chain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_chain.Location = new System.Drawing.Point(297, 34);
            this.lbl_chain.Name = "lbl_chain";
            this.lbl_chain.Size = new System.Drawing.Size(46, 17);
            this.lbl_chain.TabIndex = 8;
            this.lbl_chain.Text = "label1";
            this.lbl_chain.Visible = false;
            // 
            // pictureBox_chainLogo
            // 
            this.pictureBox_chainLogo.Location = new System.Drawing.Point(402, 34);
            this.pictureBox_chainLogo.Name = "pictureBox_chainLogo";
            this.pictureBox_chainLogo.Size = new System.Drawing.Size(242, 63);
            this.pictureBox_chainLogo.TabIndex = 13;
            this.pictureBox_chainLogo.TabStop = false;
            // 
            // lbl_resultsNum
            // 
            this.lbl_resultsNum.AutoSize = true;
            this.lbl_resultsNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_resultsNum.Location = new System.Drawing.Point(399, 270);
            this.lbl_resultsNum.Name = "lbl_resultsNum";
            this.lbl_resultsNum.Size = new System.Drawing.Size(46, 17);
            this.lbl_resultsNum.TabIndex = 14;
            this.lbl_resultsNum.Text = "label1";
            this.lbl_resultsNum.Visible = false;
            // 
            // lbl_chooseChainStore
            // 
            this.lbl_chooseChainStore.AutoSize = true;
            this.lbl_chooseChainStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_chooseChainStore.Location = new System.Drawing.Point(220, 166);
            this.lbl_chooseChainStore.Name = "lbl_chooseChainStore";
            this.lbl_chooseChainStore.Size = new System.Drawing.Size(131, 17);
            this.lbl_chooseChainStore.TabIndex = 15;
            this.lbl_chooseChainStore.Text = "Choose chain-store";
            // 
            // btn_viewCart
            // 
            this.btn_viewCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_viewCart.Location = new System.Drawing.Point(48, 175);
            this.btn_viewCart.Name = "btn_viewCart";
            this.btn_viewCart.Size = new System.Drawing.Size(75, 23);
            this.btn_viewCart.TabIndex = 16;
            this.btn_viewCart.Text = "View cart";
            this.btn_viewCart.UseVisualStyleBackColor = true;
            this.btn_viewCart.Click += new System.EventHandler(this.btn_viewCart_Click);
            // 
            // lbl_cartSize
            // 
            this.lbl_cartSize.AutoSize = true;
            this.lbl_cartSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_cartSize.Location = new System.Drawing.Point(75, 146);
            this.lbl_cartSize.Name = "lbl_cartSize";
            this.lbl_cartSize.Size = new System.Drawing.Size(16, 17);
            this.lbl_cartSize.TabIndex = 17;
            this.lbl_cartSize.Text = "0";
            // 
            // btn_comparePrices
            // 
            this.btn_comparePrices.Location = new System.Drawing.Point(34, 270);
            this.btn_comparePrices.Name = "btn_comparePrices";
            this.btn_comparePrices.Size = new System.Drawing.Size(89, 23);
            this.btn_comparePrices.TabIndex = 18;
            this.btn_comparePrices.Text = "Compare Prices";
            this.btn_comparePrices.UseVisualStyleBackColor = true;
            this.btn_comparePrices.Click += new System.EventHandler(this.btn_comparePrices_Click);
            // 
            // comboBox_city
            // 
            this.comboBox_city.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox_city.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_city.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.comboBox_city.FormattingEnabled = true;
            this.comboBox_city.Location = new System.Drawing.Point(402, 117);
            this.comboBox_city.Name = "comboBox_city";
            this.comboBox_city.Size = new System.Drawing.Size(242, 24);
            this.comboBox_city.TabIndex = 19;
            this.comboBox_city.Visible = false;
            this.comboBox_city.SelectedIndexChanged += new System.EventHandler(this.comboBox_city_SelectedIndexChanged);
            // 
            // lbl_chooseCity
            // 
            this.lbl_chooseCity.AutoSize = true;
            this.lbl_chooseCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_chooseCity.Location = new System.Drawing.Point(220, 124);
            this.lbl_chooseCity.Name = "lbl_chooseCity";
            this.lbl_chooseCity.Size = new System.Drawing.Size(81, 17);
            this.lbl_chooseCity.TabIndex = 15;
            this.lbl_chooseCity.Text = "Choose city";
            this.lbl_chooseCity.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 585);
            this.Controls.Add(this.comboBox_city);
            this.Controls.Add(this.btn_comparePrices);
            this.Controls.Add(this.lbl_cartSize);
            this.Controls.Add(this.btn_viewCart);
            this.Controls.Add(this.lbl_chooseCity);
            this.Controls.Add(this.lbl_chooseChainStore);
            this.Controls.Add(this.lbl_resultsNum);
            this.Controls.Add(this.pictureBox_chainLogo);
            this.Controls.Add(this.flowLayoutPanel_items);
            this.Controls.Add(this.btn_searchItem);
            this.Controls.Add(this.comboBox_store);
            this.Controls.Add(this.comboBox_chain);
            this.Controls.Add(this.lbl_chain);
            this.Controls.Add(this.lbl_username);
            this.Controls.Add(this.txt_searchItemName);
            this.Controls.Add(this.lbl_hello);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Price Comparer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_chainLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lbl_hello;
        private System.Windows.Forms.TextBox txt_searchItemName;
        private System.Windows.Forms.ToolStripMenuItem catalogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myCartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem priceCompareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadCartToolStripMenuItem;
        private System.Windows.Forms.Label lbl_username;
        private System.Windows.Forms.ComboBox comboBox_chain;
        private System.Windows.Forms.ComboBox comboBox_store;
        private System.Windows.Forms.Button btn_searchItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_items;
        private System.Windows.Forms.Label lbl_chain;
        private System.Windows.Forms.PictureBox pictureBox_chainLogo;
        private System.Windows.Forms.Label lbl_resultsNum;
        private System.Windows.Forms.Label lbl_chooseChainStore;
        private System.Windows.Forms.Button btn_viewCart;
        private System.Windows.Forms.Label lbl_cartSize;
        private System.Windows.Forms.Button btn_comparePrices;
        private System.Windows.Forms.ComboBox comboBox_city;
        private System.Windows.Forms.Label lbl_chooseCity;
        private System.Windows.Forms.ToolStripMenuItem storesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem priceFullToolStripMenuItem;
    }
}

