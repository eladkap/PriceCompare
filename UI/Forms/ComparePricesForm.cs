using FinalLab.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalLab.Managers;
using FinalLab.Interfaces;
using System.Collections.ObjectModel;
using FinalLab.Panels;
using UI.Panels;
using UI.Forms;

namespace FinalLab.Forms
{
    public partial class ComparePricesForm : Form
    {
        private Cart _cart;
        private CartManager _cartManager;
        private CatalogManager _catalogManager;
        private UIManager _uiManager;
        private MainForm _mainForm;
        private Chain _chain1;
        private Chain _chain2;
        private Store _store1;
        private Store _store2;
        private int kMostExpensive = 3;
        private int kMostCheap = 3;

        public ComparePricesForm()
        {
            InitializeComponent();
            AutoScroll = true;
        }

        //-------------------------Set Methods----------------------------------------------------------//

        internal void SetCart(Cart cart)
        {
            _cart = cart;
        }

        internal void SetCartManager(CartManager cartManager)
        {
            _cartManager = cartManager;
        }

        internal void SetCatalogManager(CatalogManager catalogManager)
        {
            _catalogManager = catalogManager;
        }

        internal void SetUIManager(UIManager uiManager)
        {
            _uiManager = uiManager;
        }

        internal void SetMainForm(MainForm mainForm)
        {
            _mainForm = mainForm;
        }

        //-------------------------Panel of stores from cheapest to most expansive in left side of the form--------------------------//

        public void LoadStoresTotalPricesOfCart()
        {
            ICollection<Tuple<Store, double>> storesTotalCosts = _catalogManager.GetStoresTotalCostsOfCart(_cart);
            storesTotalCosts.ToList().ForEach((storeCostTuple) => LoadStoreCost(storeCostTuple));
            SetFlowLayoutPanelStoresCost();
        }

        private void LoadStoreCost(Tuple<Store, double> storeCostTuple)
        {
            Store store = storeCostTuple.Item1;
            double totalCost = storeCostTuple.Item2;
            StoreCostPanel storeCostPanel = new StoreCostPanel(store, totalCost);
            flowLayoutPanel_storesCosts.Controls.Add(storeCostPanel.Panel);
        }

        private void SetFlowLayoutPanelStoresCost()
        {
            flowLayoutPanel_storesCosts.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel_storesCosts.AutoScroll = true;
            flowLayoutPanel_storesCosts.Height = 500;
            flowLayoutPanel_storesCosts.Width = 600;
            flowLayoutPanel_storesCosts.AutoSize = true;
            flowLayoutPanel_storesCosts.AutoScroll = true;
        }

        //-------------------------Panel of comparison between two stores--------------------------//

        public void InitializeFormComponents()
        {
            _uiManager.LoadAllChains(comboBox_chain1, false);
            _uiManager.LoadAllChains(comboBox_chain2, false);
        }

        private void comboBox_chain1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _uiManager.comboBox_chain_SelectedIndexChanged(comboBox_chain1, comboBox_store1, ref _chain1, false);
            btn_compare.Enabled = false;
            btn_showMostExpensiveCheap.Enabled = false;
            _uiManager.SetChainLogoPicture(pictureBox_chainLogo1, _chain1.ChainId);
        }

        private void comboBox_chain2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _uiManager.comboBox_chain_SelectedIndexChanged(comboBox_chain2, comboBox_store2, ref _chain2, false);
            btn_compare.Enabled = false;
            btn_showMostExpensiveCheap.Enabled = false;
            _uiManager.SetChainLogoPicture(pictureBox_chainLogo2, _chain2.ChainId);
        }

        private void comboBox_store1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _uiManager.comboBox_store_SelectedIndexChanged(comboBox_store1, ref _chain1, ref _store1);
            lbl_store1.Text = _store1.StoreName;
            if (comboBox_store2.SelectedIndex >= 0)
            {
                btn_compare.Enabled = true;
                btn_showMostExpensiveCheap.Enabled = true;
            }
        }

        private void comboBox_store2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _uiManager.comboBox_store_SelectedIndexChanged(comboBox_store2, ref _chain2, ref _store2);
            lbl_store2.Text = _store2.StoreName;
            if (comboBox_store1.SelectedIndex >= 0)
            {
                btn_compare.Enabled = true;
                btn_showMostExpensiveCheap.Enabled = true;
            }
        }

        private void btn_compare_Click(object sender, EventArgs e)
        {
            ViewComparisonPanel();
        }

        private void ViewComparisonPanel()
        {
            if (comboBox_store1.SelectedIndex < 0 || comboBox_store2.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose two stores.", "Compare prices", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            LoadComparisonItems();
        }

        private void LoadComparisonItems()
        {
            flowLayoutPanel_comparison.Controls.Clear();
            LayoutComparisonItems();
        }

        private void LoadComparisonItem(Item item)
        {
            Price price1 = _catalogManager.GetItemUpdatedPriceByStore(item, _store1);
            Price price2 = _catalogManager.GetItemUpdatedPriceByStore(item, _store2);
            flowLayoutPanel_comparison.Controls.Add(LoadItemInComparisonPanel(item, price1, price2));
        }

        private FlowLayoutPanel LoadItemInComparisonPanel(Item item, Price price1, Price price2)
        {
            CompareItemPanel compareItemPanel = new CompareItemPanel(item, price1, price2);
            return compareItemPanel.Panel;
        }

        private void SetComparisonPanel()
        {
            flowLayoutPanel_comparison.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel_comparison.AutoScroll = true;
            flowLayoutPanel_comparison.Height = 600;
            flowLayoutPanel_comparison.Width = 700;
            flowLayoutPanel_comparison.AutoSize = true;
            flowLayoutPanel_comparison.AutoScroll = true;
        }

        private void AddComparisonHeader()
        {
            CompareItemPanel compareItemPanel = new CompareItemPanel();
            compareItemPanel.AddHeader(Color.LightBlue);
            flowLayoutPanel_comparison.Controls.Add(compareItemPanel.Panel);
        }

        private void SetTotalCostsLabel(string text, double totalCost)
        {
            Label lbl_totalCost = new Label();
            lbl_totalCost.Text = text;
            lbl_totalCost.Font = new Font("Arial", 16, FontStyle.Bold);
            Label lbl_totalCostValue = new Label();
            lbl_totalCostValue.Text = $"{totalCost} [{Constants.Currency}]";
            lbl_totalCostValue.Font = new Font("Arial", 16, FontStyle.Bold);
            FlowLayoutPanel totalCostPanel = new FlowLayoutPanel();
            totalCostPanel.FlowDirection = FlowDirection.LeftToRight;
            totalCostPanel.Controls.Add(lbl_totalCost);
            totalCostPanel.Controls.Add(lbl_totalCostValue);
            flowLayoutPanel_comparison.Controls.Add(totalCostPanel);
        }

        private void AddComparisonTotalCost1()
        {
            double totalCost1 = _catalogManager.CalculateCartTotalCostByStore(_cart, _store1);
            totalCost1 = Math.Round(totalCost1, Constants.CostProximity);
            SetTotalCostsLabel("Total Cost 1", totalCost1);
        }

        private void AddComparisonTotalCost2()
        {
            double totalCost2 = _catalogManager.CalculateCartTotalCostByStore(_cart, _store2);
            totalCost2 = Math.Round(totalCost2, Constants.CostProximity);
            SetTotalCostsLabel("Total Cost 2", totalCost2);
        }

        private void AddComparisonTotalCosts()
        {
            AddComparisonTotalCost1();
            AddComparisonTotalCost2();
        }

        private void LayoutComparisonItems()
        {
            AddComparisonHeader();
            _cart.Items.ToList().ForEach((item) => LoadComparisonItem(item));
            AddComparisonTotalCosts();
            SetComparisonPanel();
        }

        private void btn_showMostExpensiveCheap_Click(object sender, EventArgs e)
        {
            ShowMostExpensiveCheap();
        }

        private void ShowMostExpensiveCheap()
        {
            ExpensiveCheapForm expensiveCheapForm = new ExpensiveCheapForm();
            expensiveCheapForm.SetProperties(_cart, _store1, _store2, kMostCheap, kMostExpensive);
            expensiveCheapForm.ShowPanel();
            expensiveCheapForm.ShowDialog();
        }
    }
}
