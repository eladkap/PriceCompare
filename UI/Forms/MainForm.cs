using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FinalLab.Managers;
using FinalLab.Entities;
using FinalLab.Forms;
using System.ComponentModel;
using XmlAccess;
using System.Threading.Tasks;

namespace FinalLab
{
    public partial class MainForm : Form
    {
        CartForm _cartForm;
        LoginForm _loginForm;
        RegisterForm _registerForm;
        ComparePricesForm _comparePricesForm;
        CatalogManager _catalogManager;
        CartManager _cartManager;
        ValidationManager _validationManager;
        AccountManager _accountManager;
        UIManager _uiManager;
        Cart _cart;
        Account _account;
        Chain _chain;
        Store _store;

        // background update arguments
        string _filePath;
        string _prefix;

        public delegate void ButtonAddToCartClickedEventHandler(object sender, EventArgs e);
        public event ButtonAddToCartClickedEventHandler AddToCartButtonClicked;

        public delegate void ButtonPriceGraphClickedEventHandler(object sender, EventArgs e);
        public event ButtonAddToCartClickedEventHandler PriceGraphButtonClicked;

        public MainForm()
        {
            InitializeComponent();
            InitializeManagers();
            InitializeAccount();
            InitializeCart();
            InitializeFormComponents();
            InitializeMenuItems();
            WindowState = FormWindowState.Maximized;
        }

        private void InitializeManagers()
        {
            _catalogManager = new CatalogManager();
            _cartManager = new CartManager();
            _validationManager = new ValidationManager();
            _accountManager = new AccountManager();
            _uiManager = new UIManager();
        }

        private void InitializeAccount()
        {
            _account = new Account();
        }

        private void InitializeCart()
        {
            _cart = new Cart();
            lbl_cartSize.Text = $"({_cart.Items.Count()})";
        }

        private void InitializeFormComponents()
        {
            lbl_username.Text = _account.Nickname;
            _uiManager.LoadAllChains(comboBox_chain, true);
            LoadAllItems();
        }

        private void LoadAllItems()
        {
            ICollection<Item> allItems = _catalogManager.GetAllItems();
            AutoCompleteStringCollection itemsCollection = new AutoCompleteStringCollection();
            allItems.ToList().ForEach((item) => itemsCollection.Add(item.ItemName));
            txt_searchItemName.AutoCompleteCustomSource = itemsCollection;
        }

        private void InitializeMenuItems()
        {
            loginToolStripMenuItem.Visible = true;
            logoutToolStripMenuItem.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private bool ValidateAdmin()
        {
            return _account.Permission.Equals("admin") || true;
        }

        internal void SetAccountLogin(bool value)
        {
            if (value)
            {
                _account.SetLogin();
            }
            else
            {
                _account.SetLogout();
            }
        }

        private void comboBox_chain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_chain.SelectedItem.ToString().Length > 0)
            {
                if (comboBox_chain.SelectedItem.ToString().Equals("All Chains"))
                {
                    comboBox_store.Enabled = false;
                    btn_searchItem.Enabled = true;
                    _uiManager.SetChainLogoPicture(pictureBox_chainLogo, "All Chains");
                    lbl_chain.Text = "כל החנויות";
                    return;
                }
                comboBox_store.Enabled = true;
                btn_searchItem.Enabled = false;

                string chainName = comboBox_chain.SelectedItem.ToString();
                _uiManager.LoadStoresByChain(chainName, comboBox_store, true);
                lbl_chain.Text = chainName;
                lbl_chain.Visible = true;
                _chain = _catalogManager.GetChainByName(chainName);
                _uiManager.SetChainLogoPicture(pictureBox_chainLogo, _chain.ChainId);
                comboBox_store.Enabled = true;
            }
        }

        //TODO: add backgroundworker to search items
        private void SearchItems()
        {
            // _backgroundWorker.DoWork += delegate (object s, DoWorkEventArgs args)
            // {
            LoadItemsByName();
            // };
            // _backgroundWorker.RunWorkerCompleted += delegate (object s, RunWorkerCompletedEventArgs args)
            // {
            //      MessageBox.Show("Search completed","Search",MessageBoxButtons.OK,MessageBoxIcon.Information);
            // };
            //_backgroundWorker.RunWorkerAsync();
        }

        private void btn_searchItem_Click(object sender, EventArgs e)
        {
            SearchItems();
        }

        private void AddItemToCart(Item item)
        {
            if (_cartManager.CartContainsItem(_cart, item))
            {
                MessageBox.Show($"Item code{ item.ItemCode} already exists in cart.", "Add Item to Cart", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                _cartManager.AddItemToCart(_cart, item);
                lbl_cartSize.Text = $"({_cart.Items.Count})";
                MessageBox.Show($"Item code{ item.ItemCode} was added to cart.", "Add Item to Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void OnAddCartButtonCicked(object sender, EventArgs e)
        {
            AddToCartButtonClicked?.Invoke(this, e);
            Button senderBtn = (Button)sender;
            FlowLayoutPanel panelParent = (FlowLayoutPanel)senderBtn.Parent;
            Item item = GetItemFromPanel(panelParent);
            _store = GetStoreFromPanel(panelParent);
            AddItemToCart(item);
        }

        private void OnPriceGraphButtonClicked(object sender, EventArgs e)
        {
            PriceGraphButtonClicked?.Invoke(this, e);
            Button senderBtn = (Button)sender;
            FlowLayoutPanel panelParent = (FlowLayoutPanel)senderBtn.Parent;
            Item item = GetItemFromPanel(panelParent);
            _store = GetStoreFromPanel(panelParent);
            ViewPriceGraph(item, _store);
        }

        private void ViewPriceGraph(Item item, Store store)
        {
            PriceGraphForm priceGraphForm = new PriceGraphForm(item, store);
            priceGraphForm.CreatePriceGraph();
            priceGraphForm.ShowDialog();
        }

        private FlowLayoutPanel LoadItemPanel(Item item, Price price, Store store)
        {
            ItemPanel itemPanel = new ItemPanel(item, price, store);
            itemPanel.BtnAddToCart.Click += new EventHandler(OnAddCartButtonCicked);
            itemPanel.BtnPriceGraph.Click += new EventHandler(OnPriceGraphButtonClicked);
            return itemPanel.Panel;
        }

        private async void PerformAsyncJob(Action PerformJob)
        {
            await System.Threading.Tasks.Task.Run(() => PerformJob());
        }

        private void LoadItem(Tuple<Item, Price, Store> itemPriceStoreTuple)
        {
            Item item = itemPriceStoreTuple.Item1;
            Price price = itemPriceStoreTuple.Item2;
            Store store = itemPriceStoreTuple.Item3;
            FlowLayoutPanel panel = LoadItemPanel(item, price, store);
            flowLayoutPanel_items.Controls.Add(panel);
            flowLayoutPanel_items.Refresh();
        }

        private void SetFlowLayoutPanelItemsProperties()
        {
            flowLayoutPanel_items.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel_items.Padding = new Padding(10, 10, 10, 10);
            flowLayoutPanel_items.WrapContents = true;
            flowLayoutPanel_items.Width = 1000;
            flowLayoutPanel_items.Height = 700;
            flowLayoutPanel_items.AutoScroll = true;
            flowLayoutPanel_items.BorderStyle = BorderStyle.FixedSingle;
        }

        private void LayoutItems(ICollection<Tuple<Item, Price, Store>> itemsPricesStoresList)
        {
            SetFlowLayoutPanelItemsProperties();
            itemsPricesStoresList.ToList().ForEach((itemPriceStoreTuple) => LoadItem(itemPriceStoreTuple));
            AutoScroll = true;
        }

        private void LoadItemsByName()
        {
            ICollection<Tuple<Item, Price, Store>> itemsPricesStoresList;
            if (comboBox_chain.SelectedItem.ToString().Equals("All Chains"))
            {
                itemsPricesStoresList = _catalogManager.GetAllUpdatedPricesByItemName(txt_searchItemName.Text);
            }
            else if (comboBox_store.SelectedItem.ToString().Equals("All Stores"))
            {
                itemsPricesStoresList = _catalogManager.GetItemsByNameAndChain(txt_searchItemName.Text, _chain);
            }
            else
            {
                itemsPricesStoresList = _catalogManager.GetItemsByNameAndStore(txt_searchItemName.Text, _store);
            }
            lbl_resultsNum.Visible = true;
            flowLayoutPanel_items.Controls.Clear();
            if (itemsPricesStoresList.Count() == 0)
            {
                lbl_resultsNum.Text = "0 results";
                return;
            }
            lbl_resultsNum.Text = $"({itemsPricesStoresList.Count().ToString()})";
            LayoutItems(itemsPricesStoresList);
        }

        private void comboBox_store_SelectedIndexChanged(object sender, EventArgs e)
        {
            string storeName = comboBox_store.SelectedItem.ToString();
            _store = _catalogManager.GetStoreByChainIdAndStoreName(_chain, storeName);
            btn_searchItem.Enabled = true;
        }

        private void ViewCart()
        {
            if (_store == null)
            {
                MessageBox.Show($"You didn't choose a store.", "View Cart", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            _cartForm = new CartForm();
            _cartForm.SetCart(_cart);
            _cartForm.SetStore(_store);
            _cartForm.SetAccount(_account);
            _cartForm.SetCartManager((CartManager)_cartManager);
            _cartForm.SetCatalogManager((CatalogManager)_catalogManager);
            _cartForm.SetMainForm(this);
            _cartForm.LoadCartItems();
            _cartForm.UpdateCartControllers();
            _cartForm.ShowDialog();
        }

        private void btn_viewCart_Click(object sender, EventArgs e)
        {
            ViewCart();
        }

        public Label GetLabelCartSize()
        {
            return lbl_cartSize;
        }

        public Label GetLabelUsername()
        {
            return lbl_username;
        }

        public ToolStripMenuItem GetLogoutMenuItem()
        {
            return logoutToolStripMenuItem;
        }

        public ToolStripMenuItem GetLoginMenuItem()
        {
            return loginToolStripMenuItem;
        }

        private Store GetStoreFromPanel(FlowLayoutPanel itemPanel)
        {
            Label lbl_storeId = (Label)(itemPanel.Controls.Find("lbl_storeId", true)).FirstOrDefault();
            string storeId = lbl_storeId.Text;
            Store store = _catalogManager.GetStoreByStoreId(storeId);
            return store;
        }
        private Item GetItemFromPanel(FlowLayoutPanel itemPanel)
        {
            Label lbl_itemCode = (Label)(itemPanel.Controls.Find("lbl_itemCode", true)).FirstOrDefault();
            string itemCode = lbl_itemCode.Text;
            Item item = _catalogManager.GetItemByItemCode(itemCode);
            return item;
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _loginForm = new LoginForm();
            _loginForm.SetAccountManager((AccountManager)_accountManager);
            _loginForm.SetValidationManager((ValidationManager)_validationManager);
            _loginForm.SetAccount(_account);
            _loginForm.SetMainForm(this);
            _loginForm.ShowDialog();
        }

        private void Logout()
        {
            MessageBox.Show($"You are logout.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            _account.SetLogout();
            GetLabelUsername().Text = "Guest";
            loginToolStripMenuItem.Visible = true;
            logoutToolStripMenuItem.Visible = false;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _registerForm = new RegisterForm();
            _registerForm.SetValidationManager((ValidationManager)_validationManager);
            _registerForm.SetAccountManager((AccountManager)_accountManager);
            _registerForm.ShowDialog();
        }

        internal void SetAccountUsername(string username)
        {
            _account.Username = username;
        }

        internal void SetAccountPermission(string permission)
        {
            _account.Permission = permission;
        }

        private void myCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewCart();
        }

        private void LoadCartFromDatabase()
        {
            Cart cart = _cartManager.LoadCartFromDatabase(_account);
            if (cart == null)
            {
                MessageBox.Show($"You don't have a cart.", "Load Cart", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            _cartManager.ClearCart(_cart);
            foreach (var cartItem in cart.Items)
            {
                Item item = _catalogManager.GetItemByItemCode(cartItem.ItemCode);
                item.QtyInPackage = cartItem.QtyInPackage;
                _cart.Items.Add(item);
            }
            ViewCart();
        }

        private void loadCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_account.IsLogin)
            {
                MessageBox.Show($"You have to log in in order to load your cart.", "Load Cart", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (_store == null)
            {
                MessageBox.Show($"Please choose at first a store.", "Load Cart", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            LoadCartFromDatabase();
        }

        private void OpenComparePricesForm()
        {
            _comparePricesForm = new ComparePricesForm();
            _comparePricesForm.SetCart(_cart);
            _comparePricesForm.SetCartManager((CartManager)_cartManager);
            _comparePricesForm.SetCatalogManager((CatalogManager)_catalogManager);
            _comparePricesForm.SetUIManager(_uiManager);
            _comparePricesForm.LoadStoresTotalPricesOfCart();
            _comparePricesForm.SetMainForm(this);
            _comparePricesForm.InitializeFormComponents();
            _comparePricesForm.ShowDialog();
        }

        private void btn_comparePrices_Click(object sender, EventArgs e)
        {
            if (_cart.Items.Count > 0)
            {
                OpenComparePricesForm();
            }
            else
            {
                MessageBox.Show("Cart is empty.", "Cart", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //------------------------------------Update database region-----------------------------------------------------------//

        private int UpdateChainStores(string storesXmlFilePath, BackgroundWorker worker, DoWorkEventArgs e)
        {
            int storesNum = _catalogManager.UpdateChainStores(storesXmlFilePath, worker, e, progressBar_update);
            return storesNum;
        }

        private int UpdateItems(string priceFullXmlFilePath)
        {
            int itemsNum = _catalogManager.UpdateItems(priceFullXmlFilePath);
            MessageBox.Show($"{itemsNum} items were inserted into database.", "Update Catalog", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return itemsNum;
        }

        private int UpdatePrices(string priceFullXmlFilePath)
        {
            int pricesNum = _catalogManager.UpdatePrices(priceFullXmlFilePath);
            MessageBox.Show($"{pricesNum} prices were inserted into database.", "Update Catalog", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return pricesNum;
        }

        private bool ValidateXmlFile(string filePath)
        {
            return XmlValidator.IsValidXmlFile(filePath);
        }

        private void StartUpdating()
        {
            Invoke(new Action(() => progressBar_update.Maximum = 100));
            Invoke(new Action(() => progressBar_update.Value = 0));
            Task.Run(() => backgroundWorkerUpdate.RunWorkerAsync());
        }

        private void OpenXmlFile()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = $"XML|{_prefix}*.xml";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                _filePath = fileDialog.FileName;
                if (ValidateXmlFile(_filePath))
                {
                    StartUpdating();
                    //PerformUpdateCatalog(filePath, prefix);
                }
                else
                {
                    MessageBox.Show($"Invalid XML file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // background update task
        private int PerformUpdateCatalog(BackgroundWorker worker, DoWorkEventArgs e)
        {
            if (_prefix.Equals("Stores"))
            {
                return UpdateChainStores(_filePath, worker, e);
            }
            else if (_prefix.Equals("PriceFull"))
            {
                return UpdateItems(_filePath) + UpdatePrices(_filePath);
            }
            return 0;
        }

        private void storesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ValidateAdmin())
            {
                MessageBox.Show("You are not an admin.", "Update Catalog", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            _prefix = "Stores";
            OpenXmlFile();
        }

        private void priceFullToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ValidateAdmin())
            {
                MessageBox.Show("You are not an admin.", "Update Catalog", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            _prefix = "PriceFull";
            OpenXmlFile();
        }

        //-------------------------------------Background Update----------------------------------------------------------//



        private void btn_cancel_Click(object sender, EventArgs e)
        {
            backgroundWorkerUpdate.CancelAsync();
        }

        private void backgroundWorkerUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            e.Result = PerformUpdateCatalog(worker, e);
        }

        private void btn_cancelUpdate_Click(object sender, EventArgs e)
        {
            backgroundWorkerUpdate.CancelAsync();
        }

        private void backgroundWorkerUpdate_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Invoke((Action)(() => progressBar_update.Value = e.ProgressPercentage));
            Invoke((Action)(() => lbl_percent.Text = $"{progressBar_update.Value}%"));
        }

        private void backgroundWorkerUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar_update.Invoke((MethodInvoker)delegate ()
            {
                progressBar_update.Value = 0;
            });
            progressBar_update.Value = 0;
            lbl_percent.Text = "0%";
            if (!e.Cancelled)
            {
                int storesNum = (int)e.Result;
                MessageBox.Show($"{storesNum} stores were inserted into database.", "Update Catalog", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Catalog was updated successfully.", "Update Catalog", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Catalog was cancelled. No records were Updated.", "Update Catalog", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
