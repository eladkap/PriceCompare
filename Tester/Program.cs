using FinalLab;
using FinalLab.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester
{
    class Program
    {
        static void TestGetChainAndItsStoresFromXml()
        {
            XmlDecoder decoder = new XmlDecoder();
            string storesXmlFilePath = $@"{Constants.XmlStoresDirPath}\Stores7290027600007-000-201608230201.xml";
            Chain chain = decoder.DecodeChainFromFile(storesXmlFilePath);
            foreach (var store in chain.Stores)
            {
                Console.WriteLine(store);
            }
        }

        static void Main(string[] args)
        {
            TestGetChainAndItsStoresFromXml();

        }
    }
}
