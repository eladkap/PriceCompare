using FinalLab.Interfaces;
using FinalLab.Managers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FinalLab.Forms
{
    public partial class PriceGraphForm : Form
    {
        private Item _item;
        private Store _store;
        private CatalogManager _catalogManager;

        public PriceGraphForm(Item item, Store store)
        {
            InitializeComponent();
            _item = item;
            _store = store;
            _catalogManager = new CatalogManager();
        }

        public void CreatePriceGraph()
        {
            ICollection<Price> pricesList = _catalogManager.GetAllPricesByItemAndStore(_item, _store);

            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.Title = "Time";
            chartArea.AxisY.Title = "Price";

            chart1.ChartAreas.Add(chartArea);

            chart1.ChartAreas[0].AxisY.ScaleView.Zoom(0, 400);
            chart1.ChartAreas[0].AxisX.ScaleView.Zoom(2010, 2016);
            chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;

            chart1.Series[0].ChartType = SeriesChartType.Line;

            var series = new Series("Price");

            foreach (var price in pricesList)
            {
                chart1.Series[0].Points.AddXY(price.UpdateTime, price.PriceValue);
            }

            chart1.Visible = true;
            chart1.Show();
        }
    }
}
