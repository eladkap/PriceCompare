using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalLab
{
    [Table("items")]
    public class Item
    {
        public Item()
        {
            Stores = new List<Store>();
            Prices = new List<Price>();
            QtyInPackage = 1;
        }

        [Key]
        [Column("item_code")]
        public string ItemCode { get; set; }

        [Column("item_type")]
        public int ItemType { get; set; }

        [Column("item_name")]
        public string ItemName { get; set; }

        [Column("manufacturer_name")]
        public string ManufacturerName { get; set; }

        [Column("manufacturer_country")]
        public string ManufacturerCountry { get; set; }

        [Column("manufacturer_item_description")]
        public string ManufacturerItemDescription { get; set; }

        [Column("unit_quantity")]
        public string UnitQty { get; set; }

        [Column("quantity")]
        public float Quantity { get; set; }

        [Column("is_weighted")]
        public bool IsWeighted { get; set; }

        [Column("unit_of_measure")]
        public string UnitOfMeasure { get; set; }

        [Column("quantity_in_package")]
        public int QtyInPackage { get; set; }

       // [Column("pic_url")]
       // public string PicUrl { get; set; }

        [NotMapped]
        public double UpdatedPrice { get; set; }

        public virtual ICollection<Price> Prices { get; set; }

        public virtual ICollection<Store> Stores { get; set; }

        public override bool Equals(object obj)
        {
            Item itemObj = (Item)obj;
            return ItemCode.Equals(itemObj.ItemCode);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
