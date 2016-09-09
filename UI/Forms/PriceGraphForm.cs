using FinalLab.Interfaces;
using FinalLab.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Windows.Forms.DataVisualization.Charting;

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
            //Chart chart;
            foreach (var price in pricesList)
            {
                //System.Diagnostics.Debug.WriteLine($"{price.UpdateTime} {price.price}");
                MessageBox.Show($"{price.UpdateTime} {price.PriceValue}");
            }
        }
    }
}
