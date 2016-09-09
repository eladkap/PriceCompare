using FinalLab;
using FinalLab.Entities;
using FinalLab.Managers;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UI.Panels;

namespace UI.Forms
{
    public partial class ExpensiveCheapForm : Form
    {
        Cart _cart;
        Store _store1;
        Store _store2;
        int _kMostCheap;
        int _kMostExpensive;
        CatalogManager _catalogManager;

        public ExpensiveCheapForm()
        {
            InitializeComponent();
            SetManagers();
            AutoScroll = true;
        }

        public void SetManagers()
        {
            _catalogManager = new CatalogManager();
        }

        public void SetProperties(Cart cart, Store store1, Store store2, int kMostCheap, int kMostExpensive)
        {
            _cart = cart;
            _store1 = store1;
            _store2 = store2;
            lbl_storeName1.Text = _store1.StoreName;
            lbl_storeName2.Text = _store2.StoreName;
            _kMostCheap = kMostCheap;
            _kMostExpensive = kMostExpensive;
        }
        public void ShowPanel()
        {
            LoadMostCheapItems(_kMostCheap, _store1);
            LoadMostExpensiveItems(_kMostExpensive, _store1);
            LoadMostCheapItems(_kMostCheap, _store2);
            LoadMostExpensiveItems(_kMostExpensive, _store2);
            SetPanels();
        }

        private ICollection<Item> GetMostExpensiveItemsInStore(ICollection<Item> itemsList, Store store)
        {
            itemsList.ToList().ForEach((item) =>
            {
                Price price = _catalogManager.GetItemUpdatedPriceByStore(item, store);
                if (price == null)
                {
                    item.UpdatedPrice = 0;
                    return;
                }
                item.UpdatedPrice = price.PriceValue;
            });
            itemsList = itemsList.OrderByDescending((item) => item.UpdatedPrice).ToList();
            return itemsList.Take(_kMostExpensive).ToList();
        }

        private ICollection<Item> GetMostCheapItemsInStore(ICollection<Item> itemsList, Store store)
        {
            itemsList.ToList().ForEach((item) =>
            {
                Price price = _catalogManager.GetItemUpdatedPriceByStore(item, store);
                if (price == null)
                {
                    item.UpdatedPrice = 0;
                    return;
                }
                item.UpdatedPrice = price.PriceValue;
            });
            itemsList = itemsList.OrderBy((item) => item.UpdatedPrice).ToList();
            return itemsList.Take(_kMostCheap).ToList();
        }

        private void LoadMostCheapItems(int kMostCheap, Store store)
        {
            ICollection<Item> itemsListMostCheap = GetMostCheapItemsInStore(_cart.Items, store);
            itemsListMostCheap.ToList().ForEach((item) => LoadCheapItem(item, store));
        }

        private void LoadMostExpensiveItems(int kMostExpensive, Store store)
        {
            ICollection<Item> itemsListMostExpensive = GetMostExpensiveItemsInStore(_cart.Items, store);
            itemsListMostExpensive.ToList().ForEach((item) => LoadExpensiveItem(item, store));
        }

        private void LoadCheapItem(Item item, Store store)
        {
            ItemPricePanel itemPricePanel = new ItemPricePanel(item, item.UpdatedPrice);
            if (store.StoreId.Equals(_store1.StoreId))
            {
                cheapPanel_store1.Controls.Add(itemPricePanel.Panel);
            }
            else
            {
                cheapPanel_store2.Controls.Add(itemPricePanel.Panel);
            }
        }

        private void LoadExpensiveItem(Item item, Store store)
        {
            ItemPricePanel itemPricePanel = new ItemPricePanel(item, item.UpdatedPrice);
            if (store.StoreId.Equals(_store1.StoreId))
            {
                expensivePanel_store1.Controls.Add(itemPricePanel.Panel);
            }
            else
            {
                expensivePanel_store2.Controls.Add(itemPricePanel.Panel);
            }
        }

        private void SetPanels()
        {
            SetPanel(cheapPanel_store1);
            SetPanel(cheapPanel_store2);
            SetPanel(expensivePanel_store1);
            SetPanel(expensivePanel_store2);
        }

        private void SetPanel(FlowLayoutPanel panel)
        {
            panel.FlowDirection = FlowDirection.TopDown;
            panel.AutoScroll = true;
            panel.Height = 500;
            panel.Width = 0;
            panel.AutoSize = true;
            panel.AutoScroll = true;
        }
    }
}
