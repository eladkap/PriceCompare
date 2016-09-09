using FinalLab.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace FinalLab.Engines
{
    public class CatalogEngine
    {
        private DatabaseConnector _connector;

        public CatalogEngine()
        {
            _connector = new DatabaseConnector();
        }

        public Chain GetChainByChainId(string chainId)
        {
            using (CatalogContext context = new CatalogContext())
            {
                return (from chain in context.Chains
                        where chain.ChainId.Equals(chainId)
                        select chain).FirstOrDefault();
            }
        }

        public Store GetStoreByStoreId(string storeId)
        {
            using (CatalogContext context = new CatalogContext())
            {
                return (from store in context.Stores
                        where store.StoreId.Equals(storeId)
                        select store).FirstOrDefault();
            }
        }

        public Item GetItemByItemCode(string itemCode)
        {
            using (CatalogContext context = new CatalogContext())
            {
                return (from item in context.Items
                        where item.ItemCode.Equals(itemCode)
                        select item).FirstOrDefault();
            }
        }

        private void PerformQuery(SqlCommand sqlCmd)
        {
            _connector.ConnectToDatabase();
            using (SqlTransaction transaction = _connector.Connection.BeginTransaction())
            {
                try
                {
                    sqlCmd.Connection = _connector.Connection;
                    sqlCmd.ExecuteNonQuery(); // async
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    throw;
                }
                finally
                {
                    _connector.DisconnectFromDatabase();
                }
            }
        }

        internal ICollection<Store> GetStoresByCity(string city)
        {
            using (CatalogContext context = new CatalogContext())
            {
                var storesCollection = from store in context.Stores
                                       where store.City.Equals(city)
                                       select store;
                return storesCollection.ToList();
            }
        }

        public ICollection<Chain> GetAllChains()
        {
            using (CatalogContext context = new CatalogContext())
            {
                var chainsCollection = from chain in context.Chains
                                       select chain;
                return chainsCollection.ToList();
            }
        }

        public ICollection<Store> GetAllStores()
        {
            using (CatalogContext context = new CatalogContext())
            {
                return (from store in context.Stores select store).ToList();
            }
        }

        public ICollection<string> GetAllCities()
        {
            using (CatalogContext context = new CatalogContext())
            {
                var citiesCollection = (from store in context.Stores
                                        select store.City).Distinct();
                return citiesCollection.ToList();
            }
        }

        public ICollection<Item> GetItemsByName(string itemName)
        {
            using (CatalogContext context = new CatalogContext())
            {
                var itemsCollection = from item in context.Items
                                      where item.ManufacturerItemDescription.Contains(itemName) || item.ItemName.Contains(itemName)
                                      select item;
                return itemsCollection.ToList();
            }
        }

        // TODO: make it async
        internal ICollection<Tuple<Item, Price, Store>> GetAllUpdatedPricesByItemName(string itemName)
        {
            using (CatalogContext context = new CatalogContext())
            {
                var pricesGroups = (from price in context.Prices
                                    join item in context.Items
                                    on price.ItemCode equals item.ItemCode
                                    join store in context.Stores
                                    on price.StoreId equals store.StoreId
                                    where item.ManufacturerItemDescription.Contains(itemName) || item.ItemName.Contains(itemName)
                                    group price by new { item.ItemCode, store.StoreId } into itemCodeGroup
                                    select itemCodeGroup).ToList();

                ICollection<Tuple<Item, Price, Store>> updatedPrices = new Collection<Tuple<Item, Price, Store>>();

                foreach (var itemCodeGroup in pricesGroups)
                {
                    Item item = GetItemByItemCode(itemCodeGroup.Key.ItemCode);
                    Store store = GetStoreByStoreId(itemCodeGroup.Key.StoreId);
                    Price updatePrice = itemCodeGroup.ToList().OrderByDescending((price) => price.UpdateTime).FirstOrDefault();
                    updatedPrices.Add(new Tuple<Item, Price, Store>(item, updatePrice, store));
                }
                return updatedPrices;
            }
        }



        internal ICollection<Store> GetStoresByChainName(string chainNameHebrew)
        {
            using (CatalogContext context = new CatalogContext())
            {
                var storesOfChainCollection = from store in context.Stores
                                              join chain in context.Chains
                                              on store.ChainId equals chain.ChainId
                                              where chain.ChainNameHebrew.Equals(chainNameHebrew)
                                              select store;
                return storesOfChainCollection.ToList();
            }
        }

        public void UpdateDatabaseFromXmlFiles()
        {
            XmlDecoder xmlDecoder = new XmlDecoder();
            string[] filePaths = filePaths = Directory.GetFiles(Constants.RootDir, "*.xml", SearchOption.AllDirectories);
            int filesCounter = 0;
            foreach (var filePath in filePaths)
            {
                //Chain chain = xmlDecoder.DeserializeChain(filePath);
                //InsertChainDetailsIntoDatabase(chain);
                filesCounter++;
                if (filesCounter == Constants.XmlFilesNumber)
                {
                    break;
                }
            }
        }

        // use this method for the graph price-time
        public ICollection<Price> GetItemPricesOrderByUpdateTime(Item item)
        {
            using (CatalogContext context = new CatalogContext())
            {
                var itemObj = (from _item in context.Items
                               where _item.ItemCode.Equals(item.ItemCode)
                               select _item).FirstOrDefault();

                return itemObj.Prices.OrderByDescending((price) => price.UpdateTime).ToList();
            }
        }

        public Price GetItemUpdatedPriceByStore(Item item, Store store)
        {
            using (CatalogContext context = new CatalogContext())
            {
                Price priceObj = (from price in context.Prices
                                  where price.ItemCode.Equals(item.ItemCode) && price.StoreId.Equals(store.StoreId)
                                  orderby price.UpdateTime descending
                                  select price).FirstOrDefault();
                return priceObj;
            }
        }

        public Store GetStoreByPrice(Price price)
        {
            using (CatalogContext context = new CatalogContext())
            {
                var storeObj = (from _price in context.Prices
                                where _price.StoreId.Equals(price.StoreId) && _price.ItemCode.Equals(price.ItemCode) && _price.UpdateTime.Equals(price.UpdateTime)
                                select _price.Store).FirstOrDefault();
                return storeObj;
            }
        }

        public Chain GetChainByName(string chainName)
        {
            using (CatalogContext context = new CatalogContext())
            {
                var chainObj = (from chain in context.Chains
                                where chain.ChainNameHebrew.Equals(chainName)
                                select chain).FirstOrDefault();
                return chainObj;
            }
        }

        public Store GetStoreByChainIdAndStoreName(Chain chain, string storeName)
        {
            using (CatalogContext context = new CatalogContext())
            {
                var storeObj = (from store in context.Stores
                                where store.ChainId.Equals(chain.ChainId) && store.StoreName.Equals(storeName)
                                select store).FirstOrDefault();
                return storeObj;
            }
        }

        public ICollection<Tuple<Item, Price, Store>> GetItemsByNameAndStore(string itemName, Store store)
        {
            ICollection<Item> itemsList = GetItemsByName(itemName);
            ICollection<Tuple<Item, Price, Store>> itemsPricesList = new List<Tuple<Item, Price, Store>>();
            itemsList.ToList().ForEach((item) =>
            {
                Price price = GetItemUpdatedPriceByStore(item, store);
                if (price != null)
                {
                    itemsPricesList.Add(new Tuple<Item, Price, Store>(item, price, store));
                }
            });
            return itemsPricesList;
        }

        public ICollection<Tuple<Item, Price, Store>> GetItemsByNameAndChain(string itemName, Chain chain)
        {
            ICollection<Item> itemsList = GetItemsByName(itemName);
            ICollection<Tuple<Item, Price, Store>> itemsPricesList = new List<Tuple<Item, Price, Store>>();
            ICollection<Store> storesInChain = GetStoresByChainName(chain.ChainNameHebrew);
            itemsList.ToList().ForEach((item) =>
            {
                foreach (var store in storesInChain)
                {
                    Price price = GetItemUpdatedPriceByStore(item, store);
                    if (price != null)
                    {
                        itemsPricesList.Add(new Tuple<Item, Price, Store>(item, price, store));
                    }
                }
            });
            return itemsPricesList;
        }

        internal ICollection<Tuple<Item, Price, Store>> GetItemsByNameAndCity(string itemName, string city)
        {
            ICollection<Item> itemsList = GetItemsByName(itemName);
            ICollection<Tuple<Item, Price, Store>> itemsPricesList = new List<Tuple<Item, Price, Store>>();
            ICollection<Store> storesInCity = GetStoresByCity(city);
            itemsList.ToList().ForEach((item) =>
            {
                foreach (var store in storesInCity)
                {
                    Price price = GetItemUpdatedPriceByStore(item, store);
                    if (price != null)
                    {
                        itemsPricesList.Add(new Tuple<Item, Price, Store>(item, price, store));
                    }
                }
            });
            return itemsPricesList;
        }

        private bool IsItemInStore(Store store, Item item)
        {
            using (CatalogContext context = new CatalogContext())
            {
                return (from price in context.Prices
                        where price.ItemCode.Equals(item.ItemCode) && price.StoreId.Equals(store.StoreId)
                        select price).Count() > 0;
            }
        }

        private bool AreAllCartItemsInStore(Cart cart, Store store)
        {
            foreach (var item in cart.Items)
            {
                if (!IsItemInStore(store, item))
                {
                    return false;
                }
            }
            return true;
        }

        public ICollection<Tuple<Store, double>> GetStoresTotalCostsOfCart(Cart cart)
        {
            ICollection<Tuple<Store, double>> storesTotalCostsCollection = new Collection<Tuple<Store, double>>();
            CartEngine cartEngine = new CartEngine();
            using (CatalogContext context = new CatalogContext())
            {
                foreach (Store store in context.Stores)
                {
                    if (AreAllCartItemsInStore(cart, store))
                    {
                        double totalCost = CalculateCartTotalCostByStore(cart, store);
                        storesTotalCostsCollection.Add(new Tuple<Store, double>(store, totalCost));
                    }
                }
            }
            return storesTotalCostsCollection.OrderBy((storeCostTuple) => storeCostTuple.Item2).ToList();
        }

        public double CalculateCartTotalCostByStore(Cart cart, Store store)
        {
            double totalCost = 0;
            foreach (Item item in cart.Items)
            {
                Price price = GetItemUpdatedPriceByStore(item, store);
                if (price != null)
                {
                    totalCost += item.QtyInPackage * price.PriceValue;
                }
            }
            return totalCost;
        }

        internal ICollection<Price> GetAllPricesByItemAndStore(Item item, Store store)
        {
            using (CatalogContext context = new CatalogContext())
            {
                var pricesList = (from price in context.Prices
                                  where price.StoreId.Equals(store.StoreId) && price.ItemCode.Equals(item.ItemCode)
                                  orderby price.UpdateTime
                                  select price);
                return pricesList.ToList();
            }
        }
    }
}
