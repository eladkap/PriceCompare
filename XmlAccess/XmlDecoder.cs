using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace FinalLab
{
    public class XmlDecoder
    {
        /*
        public Chain DeserializeChain(string path)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Chain));
                StreamReader reader = new StreamReader(path);
                Chain chain = (Chain)xmlSerializer.Deserialize(reader);
                return chain;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw;
            }
        }
        */
        public string GetChainIdFromStoreFile(XElement xmlRoot)
        {
            var chainNode = (from node in xmlRoot.Descendants()
                             where node.Name.ToString().ToLower().Equals("chainid")
                             select node).FirstOrDefault();
            if (chainNode == null)
            {
                return "None";
            }
            return chainNode.Value;
        }

        // Decode stores from file Stores.xml
        public IEnumerable<Store> GetAllStoresOfChain(XElement xmlRoot)
        {
            var storesList = from node in xmlRoot.Descendants()
                             where node.Name.ToString().ToLower().Equals("store")
                             let storeId = node.Attribute("storeid")
                             // let storeName = node.Attribute("storeName")
                             where storeId != null && storeId.Value != null
                             where String.Equals(storeId.Value, "storeid", StringComparison.OrdinalIgnoreCase)
                             select new Store()
                             {
                                 StoreId = storeId.ToString(),
                                 // StoreName = storeName.ToString()
                             };
            Console.WriteLine(storesList.Count());
            return storesList.ToList();
        }

        public Store DecodeStore(XElement storeElement)
        {
            return null;
        }

        public Chain DecodeStoresXmlFile(string xmlPath)
        {
            Chain chain = new Chain();
            XElement xmlRoot = XElement.Load(xmlPath);

            string chainId = GetChainIdFromStoreFile(xmlRoot);
            Console.WriteLine(chainId);


            //IEnumerable<Store> storesList = GetAllStores(xmlRoot);
            //storesList.ToList().ForEach((store) => Console.WriteLine(store.StoreId));

            chain.ChainId = chainId;
            return chain;
        }

        public IEnumerable<Price>  GetAllPricesOfChainStore()
        {
            return null;
        }
    }
}
