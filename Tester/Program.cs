using FinalLab;
using FinalLab.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlAccess;

namespace Tester
{
    class Program
    {
        static void TestGetChainAndItsStoresFromXml()
        {
            StoresXmlDecoder decoder = new StoresXmlDecoder();
            string storesXmlFilePath = $@"{Constants.XmlStoresDirPath}\Stores7290027600007-000-201609060827.xml";
            Chain chain = decoder.DecodeChainFromFile(storesXmlFilePath);
            foreach (var store in chain.Stores)
            {
                Console.WriteLine(store);
            }
        }

        static void TestGetItemsFromXml(int limit)
        {
            PriceFullXmlDecoder decoder = new PriceFullXmlDecoder();
            string priceFullXmlFilePath = $@"{Constants.XmlPriceFullDirPath}\PriceFull7290633800006-60-201609101723.xml";
            ICollection<Item> itemsList = decoder.DecodeItemsFromFile(priceFullXmlFilePath);
            int i = 0;
            foreach (var item in itemsList)
            {
                Console.WriteLine(item);
                i++;
                if (i == limit)
                {
                    return;
                }
            }
        }

        static void Main(string[] args)
        {
            //TestGetChainAndItsStoresFromXml();
            TestGetItemsFromXml(Constants.MaxItemsToUpdate);
        }
    }
}
