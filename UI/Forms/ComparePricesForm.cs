using FinalLab.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FinalLab.Managers;
using FinalLab.Panels;
using UI.Forms;
using Microsoft.Office.Interop.Excel;

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
            flowLayoutPanel_comparison.Height = 700;
            flowLayoutPanel_comparison.Width = 800;
            flowLayoutPanel_comparison.AutoSize = true;
            flowLayoutPanel_comparison.AutoScroll = true;
        }

        private void AddComparisonHeader()
        {
            CompareItemPanel compareItemPanel = new CompareItemPanel();
            compareItemPanel.AddHeader(Color.LightBlue);
            flowLayoutPanel_comparison.Controls.Add(compareItemPanel.Panel);
        }

        private void SetTotalCostsLabel(System.Windows.Forms.Label lbl_totalCost, double totalCost)
        {
            lbl_totalCost.Text = $"Total: {totalCost} [{Constants.Currency}]";
            lbl_totalCost.Text = $"Total: {totalCost} [{Constants.Currency}]";
        }

        private double GetTotalCostOfStore(Store store)
        {
            double totalCost = _catalogManager.CalculateCartTotalCostByStore(_cart, store);
            return Math.Round(totalCost, Constants.CostProximity);
        }

        private void SetComparisonTotalCost1()
        {
            double totalCost1 = GetTotalCostOfStore(_store1);
            SetTotalCostsLabel(lbl_totalCost1, totalCost1);
        }

        private void SetComparisonTotalCost2()
        {
            double totalCost2 = GetTotalCostOfStore(_store2);
            SetTotalCostsLabel(lbl_totalCost2, totalCost2);
        }

        private void AddComparisonTotalCosts()
        {
            SetComparisonTotalCost1();
            SetComparisonTotalCost2();
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

        //--------------------------------------------export to excel------------------------------------------------------//

        private void ExportToExcelFile()
        {
            Microsoft.Office.Interop.Excel.Application xls=new Microsoft.Office.Interop.Excel.Application();
            Workbook workBook = xls.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet worksheet = (Worksheet)xls.ActiveSheet;
            xls.Visible = true;

            worksheet.Cells[2, 1] = "Item Name";
            worksheet.Cells[1, 2] = _store1.StoreName;
            worksheet.Cells[1, 5] = _store2.StoreName;


            worksheet.Cells[2, 2] = "Price Per Unit";
            worksheet.Cells[2, 3] = "Amount";
            worksheet.Cells[2, 4] = "Total Price";
            worksheet.Cells[2, 6] = "Price Per Unit";
            worksheet.Cells[2, 7] = "Amount";
            worksheet.Cells[2, 8] = "Total Price";

            int row = 3;

            _cart.Items.ToList().ForEach((item) =>
            {
                Price price1 = _catalogManager.GetItemUpdatedPriceByStore(item, _store1);
                Price price2 = _catalogManager.GetItemUpdatedPriceByStore(item, _store2);
                worksheet.Cells[row, 1] = item.ItemName;
                worksheet.Cells[row, 2] = price1.PriceValue;
                worksheet.Cells[row, 3] = item.QtyInPackage;
                worksheet.Cells[row, 4] = item.QtyInPackage * price1.PriceValue;

                worksheet.Cells[row, 6] = price2.PriceValue;
                worksheet.Cells[row, 7] = item.QtyInPackage;
                worksheet.Cells[row, 8] = item.QtyInPackage * price2.PriceValue;

                row++;
            });

            worksheet.Cells[row, 1] = "Total Price";
            worksheet.Cells[row, 2] = GetTotalCostOfStore(_store1);
            worksheet.Cells[row, 4] = "Total Price";
            worksheet.Cells[row, 5] = GetTotalCostOfStore(_store2);

            MessageBox.Show("Excel file opened.");
        }

        private void btn_exportToExcel_Click(object sender, EventArgs e)
        {
            ExportToExcelFile();
        }
    }
}
