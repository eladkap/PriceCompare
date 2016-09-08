using FinalLab.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalLab.Interfaces
{
    interface ICatalogManager
    {
        // Insertion Methods

        /// <summary>
        /// Insert new chain into catalog or update its properties if already exists.
        /// </summary>
        /// <param name="chain">Chain</param>
        void InsertChainIntoCatalog(Chain chain);

        /// <summary>
        /// Insert new store into catalog or update its properties if already exists.
        /// </summary>
        /// <param name="store">Store</param>
        void InsertStoreIntoCatalog(Store store);

        /// <summary>
        /// Insert new item into catalog or update its properties if already exists.
        /// </summary>
        /// <param name="item">Item</param>
        void InsertItemIntoCatalog(Item item);

        /// <summary>
        /// Insert new price into catalog or update its properties if already exists.
        /// </summary>
        /// <param name="price">Price</param>
        void InsertPriceIntoCatalog(Price price);


        // Get By Id Methods

        Chain GetChainByChainId(string chainId);

        Store GetStoreByStoreId(string storeId);

        Item GetItemByItemCode(string itemCode);

        // Get Methods

        /// <summary>
        /// Return collection of all chains.
        /// </summary>
        /// <returns>Collection of all chains.</returns>
        ICollection<Chain> GetAllChains();

        ICollection<Store> GetAllStores();

        /// <summary>
        /// Return collection of stores by chain.
        /// </summary>
        /// <param name="chain">Chain</param>
        /// <returns>Collection of stores by chain</returns>
        ICollection<Store> GetStoresByChainName(string chainName);

        /// <summary>
        /// Return collection of all cities.
        /// </summary>
        /// <returns>Collection of all cities.</returns>
        ICollection<string> GetAllCities();

        /// <summary>
        /// Return collection of stores by city.
        /// </summary>
        /// <param name="city">City</param>
        /// <returns>Collection of stores by city</returns>
        ICollection<Store> GetStoresByCity(string city);

        /// <summary>
        /// Return collection of items according to name.
        /// </summary>
        /// <param name="name">Name</param>
        ICollection<Item> GetItemsByName(string name);

        ICollection<Tuple<Item, Price, Store>> GetAllUpdatedPricesByItemName(string itemName);

        /// <summary>
        /// Return collection of items according to store.
        /// </summary>
        /// <param name="store">Store</param>
        /// <returns>Collection of items</returns>
        ICollection<Item> GetItemsByStore(Store store);

        void UpdateCatalogFromXmlFiles();

        ICollection<Price> GetItemPricesOrderByUpdateTime(Item item);

        Price GetItemUpdatedPriceByStore(Item item, Store store);

        Store GetStoreByPrice(Price price);

        Chain GetChainByName(string chainName);

        ICollection<Price> GetMostUpdatedPricesByCity(string city);

        Store GetStoreByChainIdAndStoreName(Chain chain, string storeName);

        ICollection<Tuple<Item, Price, Store>> GetItemsByNameAndStore(string itemName, Store store);

        ICollection<Tuple<Item, Price, Store>> GetItemsByNameAndChain(string itemName, Chain chain);

        ICollection<Tuple<Item, Price, Store>> GetItemsByNameAndCity(string itemName, string city);

        ICollection<Tuple<Store, double>> GetStoresTotalCostsOfCart(Cart cart);

        double CalculateCartTotalCostByStore(Cart cart, Store store);

        ICollection<Price> GetAllPricesByItemAndStore(Item item, Store store);
    }
}
