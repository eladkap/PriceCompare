using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalLab.Interfaces;
using FinalLab.Engines;
using FinalLab.Entities;
using System.ComponentModel;
using System.Windows.Forms;

namespace FinalLab.Managers
{
    public class CatalogManager : ICatalogManager
    {
        private CatalogEngine catalogEngine;
        private UpdateEngine updateEngine;

        public CatalogManager()
        {
            catalogEngine = new CatalogEngine();
            updateEngine = new UpdateEngine();
        }

        public Chain GetChainByChainId(string chainId)
        {
            return catalogEngine.GetChainByChainId(chainId);
        }

        public Store GetStoreByStoreId(string storeId)
        {
            return catalogEngine.GetStoreByStoreId(storeId);
        }

        public Item GetItemByItemCode(string itemCode)
        {
            return catalogEngine.GetItemByItemCode(itemCode);
        }

        public ICollection<Chain> GetAllChains()
        {
            return catalogEngine.GetAllChains();
        }

        public ICollection<Store> GetAllStores()
        {
            return catalogEngine.GetAllStores();
        }

        public ICollection<string> GetAllCities() // async
        {
            return catalogEngine.GetAllCities();
        }

        public ICollection<Item> GetItemsByName(string itemName)
        {
            return catalogEngine.GetItemsByName(itemName);
        }

        public ICollection<Item> GetAllItems()
        {
            return catalogEngine.GetAllItems();
        }

        public ICollection<Tuple<Item, Price, Store>> GetAllUpdatedPricesByItemName(string itemName)
        {
            return catalogEngine.GetAllUpdatedPricesByItemName(itemName);
        }

        public ICollection<Item> GetItemsByStore(Store store)
        {
            throw new NotImplementedException();
        }

        public ICollection<Store> GetStoresByChainName(string chainName)
        {
            return catalogEngine.GetStoresByChainName(chainName);
        }

        public ICollection<Store> GetStoresByCity(string city)
        {
            return catalogEngine.GetStoresByCity(city);
        }

        public void InsertChainIntoCatalog(Chain chain, BackgroundWorker worker, DoWorkEventArgs e, ProgressBar progressBar)
        {
            updateEngine.InsertChainStoresIntoCatalog(chain, worker, e, progressBar);
        }

        public void InsertItemIntoCatalog(Item item)
        {
            throw new NotImplementedException();
        }

        public void InsertPriceIntoCatalog(Price price)
        {
            throw new NotImplementedException();
        }

        public void InsertStoreIntoCatalog(Store store)
        {
            throw new NotImplementedException();
        }

        public ICollection<Price> GetItemPricesOrderByUpdateTime(Item item)
        {
            return catalogEngine.GetItemPricesOrderByUpdateTime(item);
        }

        public Price GetItemUpdatedPriceByStore(Item item, Store store)
        {
            return catalogEngine.GetItemUpdatedPriceByStore(item, store);
        }

        public Store GetStoreByPrice(Price price)
        {
            return catalogEngine.GetStoreByPrice(price);
        }

        public ICollection<Price> GetMostUpdatedPricesByCity(string city)
        {
            throw new NotImplementedException();
        }

        public Chain GetChainByName(string chainName)
        {
            return catalogEngine.GetChainByName(chainName);
        }

        public Store GetStoreByChainIdAndStoreName(Chain chain, string storeName)
        {
            return catalogEngine.GetStoreByChainIdAndStoreName(chain, storeName);
        }

        public ICollection<Tuple<Item, Price, Store>> GetItemsByNameAndStore(string itemName, Store store)
        {
            return catalogEngine.GetItemsByNameAndStore(itemName, store);
        }

        public ICollection<Tuple<Item, Price, Store>> GetItemsByNameAndChain(string itemName, Chain chain)
        {
            return catalogEngine.GetItemsByNameAndChain(itemName, chain);
        }

        public ICollection<Tuple<Item, Price, Store>> GetItemsByNameAndCity(string itemName, string city)
        {
            return catalogEngine.GetItemsByNameAndCity(itemName, city);
        }

        public ICollection<Tuple<Store, double>> GetStoresTotalCostsOfCart(Cart cart)
        {
            return catalogEngine.GetStoresTotalCostsOfCart(cart);
        }

        public double CalculateCartTotalCostByStore(Cart cart, Store store)
        {
            return catalogEngine.CalculateCartTotalCostByStore(cart, store);
        }

        public ICollection<Price> GetAllPricesByItemAndStore(Item item, Store store)
        {
            return catalogEngine.GetAllPricesByItemAndStore(item, store);
        }

        public int UpdateChainStores(string storesXmlFilePath, BackgroundWorker worker, DoWorkEventArgs e, ProgressBar progressBar)
        {
            return updateEngine.UpdateChainStores(storesXmlFilePath, worker, e, progressBar);
        }

        public int UpdateItems(string priceFullXmlFilePath, BackgroundWorker worker, DoWorkEventArgs e, ProgressBar progressBar)
        {
            return updateEngine.UpdateItems(priceFullXmlFilePath, worker, e, progressBar);
        }

        public int UpdatePrices(string priceFullXmlFilePath, BackgroundWorker worker, DoWorkEventArgs e, ProgressBar progressBar)
        {
            return updateEngine.UpdatePrices(priceFullXmlFilePath, worker, e, progressBar);
        }
    }
}
