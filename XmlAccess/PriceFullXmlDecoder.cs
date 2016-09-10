using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalLab;
using System.Xml.Linq;
using System.Collections.ObjectModel;

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
            IEnumerable<XElement> itemsElements = GetAllitemElements(xmlRoot);
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

        private IEnumerable<XElement> GetAllitemElements(XElement xmlRoot)
        {
            return (from node in xmlRoot.Descendants()
                    where node.Name.ToString().ToLower().Equals("item") || node.Name.ToString().ToLower().Equals("product")
                    select node);
        }

        private string DecodeItemField(XElement itemElement, string fieldName)
        {
            var fieldElement = (from node in itemElement.Descendants()
                                where node.Name.ToString().ToLower().Equals(fieldName)
                                select node).FirstOrDefault();
            return fieldElement?.Value;
        }

        private string DecodeItemCode(XElement itemElement)
        {
            return DecodeItemField(itemElement, "itemcode");
        }

        private string DecodeItemName(XElement itemElement)
        {
            return DecodeItemField(itemElement, "itemname");
        }

        private string DecodeManufacturerName(XElement itemElement)
        {
            return DecodeItemField(itemElement, "manufacturername");
        }

        private string DecodeManufacturerCountry(XElement itemElement)
        {
            return DecodeItemField(itemElement, "manufacturercountry");
        }

        private string DecodeManufacturerItemDescription(XElement itemElement)
        {
            return DecodeItemField(itemElement, "manufactureritemdescription");
        }

        private string DecodeUnitQty(XElement itemElement)
        {
            return DecodeItemField(itemElement, "unitqty");
        }

        private string DecodeUnitOfMeasure(XElement itemElement)
        {
            return DecodeItemField(itemElement, "unitofmeasure");
        }

        private int DecodeItemType(XElement itemElement)
        {
            return DecodeItemFieldInt(itemElement, "itemtype");
        }

        private int DecodeQtyInPackage(XElement itemElement)
        {
            return DecodeItemFieldInt(itemElement, "qtyinpackage");
        }

        private float DecodeQuantity(XElement itemElement)
        {
            return DecodeItemFieldFloat(itemElement, "quantity");
        }

        private bool DecodeIsWeighted(XElement itemElement)
        {
            return DecodeItemFieldBool(itemElement, "isweighted");
        }

        //-------------------------Helper methods for converting db fields string to int, bool ,float--------------------------//

        private int DecodeItemFieldInt(XElement itemElement, string fieldName)
        {
            var fieldValueString = DecodeItemField(itemElement, fieldName);
            if (fieldValueString == null)
            {
                return default(int);
            }
            int fieldValueInt = default(int);
            bool result = int.TryParse(fieldValueString, out fieldValueInt);
            return fieldValueInt;
        }

        private bool DecodeItemFieldBool(XElement itemElement, string fieldName)
        {
            var fieldValueString = DecodeItemField(itemElement, fieldName);
            if (fieldValueString == null)
            {
                return default(bool);
            }
            bool fieldValueBool = default(bool);
            bool result = bool.TryParse(fieldValueString, out fieldValueBool);
            return fieldValueBool;
        }

        private float DecodeItemFieldFloat(XElement itemElement, string fieldName)
        {
            var fieldValueString = DecodeItemField(itemElement, fieldName);
            if (fieldValueString == null)
            {
                return default(float);
            }
            float fieldValueFloat = default(float);
            bool result = float.TryParse(fieldValueString, out fieldValueFloat);
            return fieldValueFloat;
        }



        //----------------------------------------Price---------------------------------------------------------//
    }
}
