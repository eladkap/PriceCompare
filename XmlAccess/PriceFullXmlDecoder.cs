using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalLab;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using Utilities;

namespace XmlAccess
{
    public class PriceFullXmlDecoder
    {
        //----------------------------------------Item---------------------------------------------------------//
        public ICollection<Item> DecodeItemsFromFile(string priceFullXmlFilePath)
        {
            XElement xmlRoot = XElement.Load(priceFullXmlFilePath);
            if (xmlRoot == null)
            {
                return null;
            }
            return DecodeItemsElements(xmlRoot);
        }

        private ICollection<Item> DecodeItemsElements(XElement xmlRoot)
        {
            IEnumerable<XElement> itemsElements = GetAllItemElements(xmlRoot);
            ICollection<Item> itemsList = new Collection<Item>();
            foreach (XElement itemElement in itemsElements)
            {
                Item item = DecodeItem(itemElement);
                itemsList.Add(item);
            }
            return itemsList;
        }

        private Item DecodeItem(XElement itemElement)
        {
            string itemCode = DecodeItemCode(itemElement);
            int itemType = DecodeItemType(itemElement);
            string itemName = DecodeItemName(itemElement);
            string manufacturerName = DecodeManufacturerName(itemElement);
            string manufacturerCountry = DecodeManufacturerCountry(itemElement);
            string manufacturerItemDescription = DecodeManufacturerItemDescription(itemElement);
            string unitQty = DecodeUnitQty(itemElement);
            float quantity = DecodeQuantity(itemElement); ;
            bool isWeighted = DecodeIsWeighted(itemElement); ;
            string unitOfMeasure = DecodeUnitOfMeasure(itemElement); ;
            int qtyInPackage = DecodeQtyInPackage(itemElement); ;

            return new Item()
            {
                ItemCode = itemCode,
                ItemType = itemType,
                ItemName = itemName,
                ManufacturerName = manufacturerName,
                ManufacturerCountry = manufacturerCountry,
                ManufacturerItemDescription = manufacturerItemDescription,
                UnitQty = unitQty,
                Quantity = quantity,
                IsWeighted = isWeighted,
                UnitOfMeasure = unitOfMeasure,
                QtyInPackage = qtyInPackage
            };
        }

        private IEnumerable<XElement> GetAllItemElements(XElement xmlRoot)
        {
            return (from node in xmlRoot.Descendants()
                    where node.Name.ToString().ToLower().Equals("item") || node.Name.ToString().ToLower().Equals("product")
                    select node);
        }

        private string DecodeItemCode(XElement itemElement)
        {
            return FieldConverter.DecodeItemField(itemElement, "itemcode");
        }

        private string DecodeItemName(XElement itemElement)
        {
            return FieldConverter.DecodeItemField(itemElement, "itemname");
        }

        private string DecodeManufacturerName(XElement itemElement)
        {
            return FieldConverter.DecodeItemField(itemElement, "manufacturername");
        }

        private string DecodeManufacturerCountry(XElement itemElement)
        {
            return FieldConverter.DecodeItemField(itemElement, "manufacturercountry");
        }

        private string DecodeManufacturerItemDescription(XElement itemElement)
        {
            return FieldConverter.DecodeItemField(itemElement, "manufactureritemdescription");
        }

        private string DecodeUnitQty(XElement itemElement)
        {
            return FieldConverter.DecodeItemField(itemElement, "unitqty");
        }

        private string DecodeUnitOfMeasure(XElement itemElement)
        {
            return FieldConverter.DecodeItemField(itemElement, "unitofmeasure");
        }

        private int DecodeItemType(XElement itemElement)
        {
            return FieldConverter.DecodeItemFieldInt(itemElement, "itemtype");
        }

        private int DecodeQtyInPackage(XElement itemElement)
        {
            return FieldConverter.DecodeItemFieldInt(itemElement, "qtyinpackage");
        }

        private float DecodeQuantity(XElement itemElement)
        {
            return FieldConverter.DecodeItemFieldFloat(itemElement, "quantity");
        }

        private bool DecodeIsWeighted(XElement itemElement)
        {
            return FieldConverter.DecodeItemFieldBool(itemElement, "isweighted");
        }

        //-------------------------Helper methods for converting db fields string to int, bool ,float--------------------------//



        //----------------------------------------Price---------------------------------------------------------//

        public ICollection<Price> DecodePricesFromFile(string priceFullXmlFilePath)
        {
            XElement xmlRoot = XElement.Load(priceFullXmlFilePath);
            if (xmlRoot == null)
            {
                return null;
            }
            return DecodePricesElements(xmlRoot);
        }

        private ICollection<Price> DecodePricesElements(XElement xmlRoot)
        {
            string storeId = $"{DecodeChainId(xmlRoot)}_{DecodeStoreId(xmlRoot)}";
            IEnumerable<XElement> itemElements = GetAllItemElements(xmlRoot);
            ICollection<Price> pricesList = new Collection<Price>();
            foreach (XElement itemElement in itemElements)
            {
                Price price = DecodePrice(itemElement, storeId);
                pricesList.Add(price);
            }
            return pricesList;
        }

        private Price DecodePrice(XElement itemElement, string storeId)
        {
            string itemCode = DecodeItemCode(itemElement);
            float itemPrice = FieldConverter.DecodeItemFieldFloat(itemElement, "itemprice");
            DateTime updateTime = FieldConverter.DecodeItemFieldDateTime(itemElement, "priceupdatedate");
            bool allowDiscount = FieldConverter.DecodeItemFieldBool(itemElement, "allowdiscount");
            return new Price()
            {
                StoreId = storeId,
                ItemCode = itemCode,
                PriceValue = itemPrice,
                UpdateTime = updateTime,
                AllowDiscount = allowDiscount
            };
        }

        // helper methods to decode from PriceFull storeId and chainId// 
        private string DecodeChainId(XElement xmlRoot)
        {
            var chainNode = (from node in xmlRoot.Descendants()
                             where node.Name.ToString().ToLower().Equals("chainid")
                             select node).FirstOrDefault();
            return chainNode.Value;
        }

        private string DecodeStoreId(XElement xmlRoot)
        {
            var storeNode = (from node in xmlRoot.Descendants()
                             where node.Name.ToString().ToLower().Equals("storeid")
                             select node).FirstOrDefault();
            return storeNode.Value;
        }
    }
}
