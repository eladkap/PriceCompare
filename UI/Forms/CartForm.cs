using FinalLab.Entities;
using FinalLab.Interfaces;
using FinalLab.Managers;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FinalLab.Forms
{
    public partial class CartForm : Form
    {
        private MainForm _mainForm;
        private Cart _cart;
        private Chain _chain;
        private Store _store;
        private Account _account;
        private CartManager _cartManager;
        private CatalogManager _catalogManager;

        public delegate void ButtonRemoveFromCartClickedEventHandler(object sender, EventArgs e);
        public event ButtonRemoveFromCartClickedEventHandler RemoveFromCartButtonClicked;

        public delegate void ButtonIncrementUnitClickedEventHandler(object sender, EventArgs e);
        public event ButtonIncrementUnitClickedEventHandler IncrementUnitButtonClicked;

        public delegate void ButtonDecrementUnitClickedEventHandler(object sender, EventArgs e);
        public event ButtonDecrementUnitClickedEventHandler DecrementUnitButtonClicked;

        public CartForm()
        {
            InitializeComponent();
            AutoScroll = true;
        }

        private void InitializeCart()
        {
            lbl_cartSize.Text = $"{_cart.Items.Count}";
        }

        public void SetCart(Cart cart)
        {
            _cart = cart;
            InitializeCart();
            _catalogManager = new CatalogManager();
        }

        public void SetStore(Store store)
        {
            _store = store;
            _chain = _catalogManager.GetChainByChainId(_store.ChainId);
            lbl_chainStore.Text = $"{_chain.ChainNameHebrew} {_store.StoreName}";
        }

        public void SetAccount(Account account)
        {
            _account = account;
        }

        public void SetCartManager(CartManager cartManager)
        {
            _cartManager = cartManager;
        }

        public void SetCatalogManager(CatalogManager catalogManager)
        {
            _catalogManager = catalogManager;
        }

        public void SetMainForm(MainForm mainForm)
        {
            _mainForm = mainForm;
        }

        private void SetCartProperties()
        {
            _cart.TimeCreated = DateTime.Now;
            _cart.Username = _account.Username;
        }

        private void SaveCartInDatabase()
        {
            SetCartProperties();
            _cartManager.RemoveCartRecordsByUsername(_account.Username);
            _cartManager.SaveCartInDatabase(_cart);
            MessageBox.Show("Cart was saved successfully.", "Saving Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_saveCart_Click(object sender, EventArgs e)
        {
            if (!_account.IsLogin)
            {
                MessageBox.Show("You have to log in in order to save your cart.", "Saving Cart", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SaveCartInDatabase();
        }

        private void btn_clearCart_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear your cart?", "Clear Cart", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _cartManager.ClearCart(_cart);
                ClearAllItemsPanelsFromCart();
                UpdateCartControllers();
            }
        }

        private void RemoveItemPanelFromCart(FlowLayoutPanel cartPanel)
        {
            flowLayoutPanel_cartPanel.Controls.Remove(cartPanel);
        }

        private void ClearAllItemsPanelsFromCart()
        {
            flowLayoutPanel_cartPanel.Controls.Clear();
        }

        private void RemoveItemFromCart(Item item, FlowLayoutPanel cartPanel)
        {
            if (MessageBox.Show("Are you sure you want to remove this item?", "Remove Item from Cart", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _cartManager.RemoveItemFromCart(_cart, item);
                RemoveItemPanelFromCart(cartPanel);
                UpdateCartControllers();
            }
        }

        private void OnRemoveCartButtonClicked(object sender, EventArgs e)
        {
            RemoveFromCartButtonClicked?.Invoke(this, e);
            Button senderBtn = (Button)sender;
            FlowLayoutPanel itemInCartPanel = (FlowLayoutPanel)senderBtn.Parent;
            Item item = GetItemFromPanel(itemInCartPanel);
            RemoveItemFromCart(item, itemInCartPanel);
        }

        internal void UpdateCartControllers()
        {
            lbl_cartSize.Text = $"({_cart.Items.Count()})";
            _mainForm.GetLabelCartSize().Text = $"({_cart.Items.Count()})";
            double totalCost = _catalogManager.CalculateCartTotalCostByStore(_cart, _store);
            totalCost = Math.Round(totalCost, Constants.CostProximity);
            lbl_totalCost.Text = $"{totalCost} {Constants.Currency}";
        }

        /// <summary>
        /// General action: increment (action=1) or decrement (action=-1). 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="price"></param>
        /// <param name="itemInCartPanel"></param>
        /// <param name="action"></param>
        private void UpdateUnits(Item item, Price price, FlowLayoutPanel itemInCartPanel, int action)
        {
            if (action == 1)
            {
                _cartManager.IncrementItemUnitToCart(_cart, item);
            }
            else
            {
                _cartManager.DecrementItemUnitToCart(_cart, item);
            }
            int amount = _cartManager.GetCartItemAmount(_cart, item);
            Label lbl_amountUnit = GetAmountLabelFromPanel(itemInCartPanel);
            lbl_amountUnit.Text = $"{amount}";
            Label lbl_priceUnit = GetPriceUnitLabelFromPanel(itemInCartPanel);
            if (price == null)
            {
                lbl_priceUnit.Text = $"? {Constants.Currency}";
                Label lbl_priceTotal = GetPriceTotalLabelFromPanel(itemInCartPanel);
                lbl_priceTotal.Text = $"? {Constants.Currency}";
            }
            else
            {
                lbl_priceUnit.Text = $"{price.price} {Constants.Currency}";
                Label lbl_priceTotal = GetPriceTotalLabelFromPanel(itemInCartPanel);
                lbl_priceTotal.Text = $"{price.price * amount} {Constants.Currency}";
            }
            if (_cartManager.GetCartItemAmount(_cart, item) == 0)
            {
                MessageBox.Show("Decremented to zero.");
                RemoveItemFromCart(item, itemInCartPanel);
            }

            UpdateCartControllers();
        }

        //---------------helper methods----------------------
        private Price GetPriceFromPanel(Item item, FlowLayoutPanel itemInCartPanel)
        {
            return _catalogManager.GetItemUpdatedPriceByStore(item, _store);
        }

        private Item GetItemFromPanel(FlowLayoutPanel itemInCartPanel)
        {
            Label lbl_itemCode = (Label)(itemInCartPanel.Controls.Find("lbl_itemCode", true)).FirstOrDefault();
            string itemCode = lbl_itemCode.Text;
            Item item = _catalogManager.GetItemByItemCode(itemCode);
            return item;
        }

        private Label GetAmountLabelFromPanel(FlowLayoutPanel itemInCartPanel)
        {
            return (Label)(itemInCartPanel.Controls.Find("lbl_amount", true)).FirstOrDefault();
        }

        private Label GetPriceUnitLabelFromPanel(FlowLayoutPanel itemInCartPanel)
        {
            return (Label)(itemInCartPanel.Controls.Find("lbl_priceUnit", true)).FirstOrDefault();
        }

        private Label GetPriceTotalLabelFromPanel(FlowLayoutPanel itemInCartPanel)
        {
            return (Label)(itemInCartPanel.Controls.Find("lbl_priceTotal", true)).FirstOrDefault();
        }


        //---------------Increment unit----------------------
        private void IncrementUnit(Item item, Price price, FlowLayoutPanel itemInCartPanel)
        {
            UpdateUnits(item, price, itemInCartPanel, 1);
        }

        private void OnIncrementUnitButtonClicked(object sender, EventArgs e)
        {
            IncrementUnitButtonClicked?.Invoke(this, e);
            Button senderBtn = (Button)sender;
            FlowLayoutPanel itemInCartPanel = (FlowLayoutPanel)senderBtn.Parent;
            Item item = GetItemFromPanel(itemInCartPanel);
            Price price = GetPriceFromPanel(item, itemInCartPanel);
            IncrementUnit(item, price, itemInCartPanel);
        }

        // Decrement unit
        private void DecrementUnit(Item item, Price price, FlowLayoutPanel itemInCartPanel)
        {
            UpdateUnits(item, price, itemInCartPanel, -1);
        }

        private void OnDecrementUnitButtonClicked(object sender, EventArgs e)
        {
            DecrementUnitButtonClicked?.Invoke(this, e);
            Button senderBtn = (Button)sender;
            FlowLayoutPanel itemInCartPanel = (FlowLayoutPanel)senderBtn.Parent;
            Item item = GetItemFromPanel(itemInCartPanel);
            Price price = GetPriceFromPanel(item, itemInCartPanel);
            DecrementUnit(item, price, itemInCartPanel);
        }

        // Load cart items

        private Panel LoadItemInCartPanel(Item item, Price price, Store store)
        {
            ItemInCartPanel itemInCartPanel = new ItemInCartPanel(item, price);
            itemInCartPanel.BtnRemoveFromCart.Click += new EventHandler(OnRemoveCartButtonClicked);
            itemInCartPanel.BtnIncrementUnit.Click += new EventHandler(OnIncrementUnitButtonClicked);
            itemInCartPanel.BtnDecrementUnit.Click += new EventHandler(OnDecrementUnitButtonClicked);
            return itemInCartPanel.Panel;
        }

        private void LoadItem(Item item)
        {
            Price price = _catalogManager.GetItemUpdatedPriceByStore(item, _store);
            flowLayoutPanel_cartPanel.Controls.Add(LoadItemInCartPanel(item, price, _store));
        }

        private void SetCartFlowLayoutPanel()
        {
            flowLayoutPanel_cartPanel.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel_cartPanel.AutoScroll = true;
            flowLayoutPanel_cartPanel.Height = 600;
            flowLayoutPanel_cartPanel.Width = 900;
            flowLayoutPanel_cartPanel.AutoSize = true;
            flowLayoutPanel_cartPanel.AutoScroll = true;
        }

        private void LayoutCartItems()
        {
            _cart.Items.ToList().ForEach((item) => LoadItem(item));
            SetCartFlowLayoutPanel();
        }

        internal void LoadCartItems()
        {
            flowLayoutPanel_cartPanel.Controls.Clear();
            LayoutCartItems();
        }
    }
}
