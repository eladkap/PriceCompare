using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using XmlAccess;

namespace FinalLab.Engines
{
    public class UpdateEngine
    {
        internal int UpdateChainStores(string storesXmlFilePath, BackgroundWorker worker, DoWorkEventArgs e, ProgressBar progressBar)
        {
            StoresXmlDecoder xmlDecoder = new StoresXmlDecoder();
            Chain chain = xmlDecoder.DecodeChainFromFile(storesXmlFilePath);
            int storeNum = InsertChainStoresIntoCatalog(chain, worker, e, progressBar);
            return storeNum;
        }

        internal int UpdatePrices(string priceFullXmlFilePath, BackgroundWorker worker, DoWorkEventArgs e, ProgressBar progressBar)
        {
            PriceFullXmlDecoder xmlDecoder = new PriceFullXmlDecoder();
            ICollection<Price> pricesList = xmlDecoder.DecodePricesFromFile(priceFullXmlFilePath);
            int pricesNum = InsertPricesIntoCatalog(pricesList, worker, e, progressBar);
            return pricesNum;
        }

        internal int UpdateItems(string priceFullXmlFilePath, BackgroundWorker worker, DoWorkEventArgs e, ProgressBar progressBar)
        {
            PriceFullXmlDecoder xmlDecoder = new PriceFullXmlDecoder();
            ICollection<Item> itemsList = xmlDecoder.DecodeItemsFromFile(priceFullXmlFilePath);
            int itemsNum = InsertItemsIntoCatalog(itemsList, worker, e, progressBar);
            return itemsNum;
        }

        private int InsertItemsIntoCatalog(ICollection<Item> itemsList, BackgroundWorker worker, DoWorkEventArgs e, ProgressBar progressBar)
        {
            //int totalItems = itemsList.Count();
            int totalItems = Constants.MaxItemsToUpdate;
            using (CatalogContext context = new CatalogContext())
            {
                int itemsNum = 0;
                foreach (var item in itemsList)
                {
                    // check if cancel
                    if (worker != null && worker.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }

                    UpdateProgressBar(progressBar, itemsNum, totalItems, "items");

                    bool itemExists = context.Items.Any(currItem => currItem.ItemCode.Equals(item.ItemCode));
                    if (!itemExists)
                    {
                        context.Items.Add(item);
                        itemsNum++;
                        if (itemsNum == Constants.MaxItemsToUpdate)
                        {
                            break;
                        }
                    }
                }
                if (!e.Cancel)
                {
                    context.SaveChanges();
                    return itemsNum;
                }
                return 0;
            }
        }

        private int InsertPricesIntoCatalog(ICollection<Price> pricesList, BackgroundWorker worker, DoWorkEventArgs e, ProgressBar progressBar)
        {
            //int totalPrices = pricesList.Count();
            int totalPrices = Constants.MaxPricesToUpdate;
            using (CatalogContext context = new CatalogContext())
            {
                int pricesNum = 0;
                foreach (var price in pricesList)
                {
                    // check if cancel
                    if (worker != null && worker.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }

                    UpdateProgressBar(progressBar, pricesNum, totalPrices, "prices");

                    bool itemExist = context.Items.Any(currItem => currItem.ItemCode.Equals(price.ItemCode));
                    bool priceExists = context.Prices.Any(currPrice => currPrice.StoreId.Equals(price.StoreId) && currPrice.ItemCode.Equals(price.ItemCode) && currPrice.UpdateTime.Equals(price.UpdateTime));
                    if (!priceExists && itemExist)
                    {
                        context.Prices.Add(price);
                        pricesNum++;
                        if (pricesNum == Constants.MaxPricesToUpdate)
                        {
                            break;
                        }
                    }
                }
                if (!e.Cancel)
                {
                    context.SaveChanges();
                    return pricesNum;
                }
                return 0;
            }
        }

        public int InsertChainStoresIntoCatalog(Chain chain, BackgroundWorker worker, DoWorkEventArgs e, ProgressBar progressBar)
        {
            int totalStores = chain.Stores.Count();
            using (CatalogContext context = new CatalogContext())
            {
                bool chainExists = context.Chains.Any(currChain => currChain.ChainId.Equals(chain.ChainId));
                if (!chainExists)
                {
                    context.Chains.Add(chain);
                }
                int storesNum = 0;
                foreach (var store in chain.Stores)
                {
                    Thread.Sleep(100);
                    // check if cancel
                    if (worker != null && worker.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }

                    UpdateProgressBar(progressBar, storesNum, totalStores, "stores");

                    bool storeExists = context.Stores.Any(currStore => currStore.StoreId.Equals(store.StoreId));
                    if (!storeExists)
                    {
                        context.Stores.Add(store);
                        storesNum++;
                    }
                }
                if (!e.Cancel)
                {
                    context.SaveChanges();
                    return storesNum;
                }
                return 0;
            }
        }

        private void UpdateProgressBar(ProgressBar progressBar, int records, int totalRecords, string entities)
        {
            int percentComplete = (int)((records) / (float)(totalRecords) * 100);
            progressBar.Invoke((MethodInvoker)delegate ()
            {
                progressBar.Value = percentComplete;
            });
            SetProgressBarPercentage(progressBar, percentComplete, entities);
        }

        private void SetProgressBarPercentage(ProgressBar progressBar, int percentComplete, string entities)
        {
            progressBar.CreateGraphics().DrawString($"Updating {entities}... {percentComplete.ToString()}%",
                new Font("Arial", 8.25f, FontStyle.Regular), Brushes.Black,
                new PointF(progressBar.Width / 2 - 10, progressBar.Height / 2 - 7));
        }
    }
}
