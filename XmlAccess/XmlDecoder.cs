using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;

namespace FinalLab
{
    public class XmlDecoder
    {
        //----------------------------------------Chain---------------------------------------------------------//
        private string DecodeChainId(XElement xmlRoot)
        {
            var chainNode = (from node in xmlRoot.Descendants()
                             where node.Name.ToString().ToLower().Equals("chainid")
                             select node).FirstOrDefault();
            return chainNode.Value;
        }

        private string DecodeChainName(XElement xmlRoot)
        {
            var chainNode = (from node in xmlRoot.Descendants()
                             where node.Name.ToString().ToLower().Equals("chainname")
                             select node).FirstOrDefault();
            return chainNode.Value;
        }

        public Chain DecodeChain(XElement xmlRoot)
        {
            var chainId = DecodeChainId(xmlRoot);
            var chainName = DecodeChainName(xmlRoot);
            return new Chain()
            {
                ChainId = chainId,
                ChainName = chainName,
                ChainNameHebrew = chainName,
                Stores = DecodeStoresElements(xmlRoot, chainId)
            };
        }

        //----------------------------------------Stores---------------------------------------------------------//

        private IEnumerable<XElement> GetAllStoreElements(XElement xmlRoot)
        {
            return (from node in xmlRoot.Descendants()
                    where node.Name.ToString().ToLower().Equals("store")
                    select node);
        }

        private string DecodeStoreField(XElement storeElement, string fieldName)
        {
            var storeIdElement = (from node in storeElement.Descendants()
                                  where node.Name.ToString().ToLower().Equals(fieldName)
                                  select node).FirstOrDefault();
            return storeIdElement?.Value;
        }

        private string DecodeStoreId(XElement storeElement)
        {
            return DecodeStoreField(storeElement, "storeid");
        }

        private string DecodeStoreName(XElement storeElement)
        {
            return DecodeStoreField(storeElement, "storename");
        }

        private string DecodeStoreSubchainName(XElement storeElement)
        {
            return DecodeStoreField(storeElement, "subchainname");
        }

        private string DecodeStoreAddress(XElement storeElement)
        {
            return DecodeStoreField(storeElement, "address");
        }

        private string DecodeStoreCity(XElement storeElement)
        {
            return DecodeStoreField(storeElement, "city");
        }

        private string DecodeStoreZipcode(XElement storeElement)
        {
            return DecodeStoreField(storeElement, "zipcode");
        }

        private string DecodeStoreBikoretNo(XElement storeElement)
        {
            return DecodeStoreField(storeElement, "bikoretno");
        }

        private Store DecodeStore(XElement storeElement, string chainId)
        {
            var storeId = $"{chainId}_{DecodeStoreId(storeElement)}";
            ; var storeName = DecodeStoreName(storeElement);
            var subchainName = DecodeStoreSubchainName(storeElement);
            var address = DecodeStoreAddress(storeElement);
            var city = DecodeStoreCity(storeElement);
            var zipcode = DecodeStoreZipcode(storeElement);

            int bikoretNoInt = 0;
            var bikoretNoString = DecodeStoreBikoretNo(storeElement);
            bool result = int.TryParse(bikoretNoString, out bikoretNoInt);
            if (!result)
            {
                bikoretNoInt = -1;
            }

            return new Store()
            {
                StoreId = $"{chainId}{storeId}",
                ChainId = chainId,
                StoreName = storeName,
                SubchainName = subchainName,
                City = city,
                Address = address,
                Zipcode = zipcode,
                BikoretNo = bikoretNoInt
            };
        }

        public ICollection<Store> DecodeStoresElements(XElement xmlRoot, string chainId)
        {
            IEnumerable<XElement> storesElements = GetAllStoreElements(xmlRoot);
            ICollection<Store> storesList = new Collection<Store>();
            foreach (XElement storeElement in storesElements)
            {
                Store store = DecodeStore(storeElement, chainId);
                storesList.Add(store);
            }
            return storesList;
        }

        public Chain DecodeChainFromFile(string xmlFilePath)
        {
            XElement xmlRoot = XElement.Load(xmlFilePath);
            return DecodeChain(xmlRoot);
        }

        public IEnumerable<Price> GetAllPricesOfChainStore()
        {
            return null;
        }
    }
}
