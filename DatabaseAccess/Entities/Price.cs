using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalLab
{
    [Table("prices")]
    public class Price
    {

        [Key, Column("store_id", Order = 0)]
        public string StoreId { get; set; }

        [Key, Column("item_code", Order = 1)]
        public string ItemCode { get; set; }

        [Key, Column("update_time", Order = 2)]
        public DateTime UpdateTime { get; set; }

        [Column("price")]
        public float PriceValue { get; set; }

        [Column("allow_discount")]
        public bool AllowDiscount { get; set; }

        [NotMapped]
        public virtual Store Store { get; set; }

        [NotMapped]
        public virtual Item Item { get; set; }

        public override bool Equals(object obj)
        {
            Price priceObj = (Price)obj;
            return StoreId.Equals(priceObj.StoreId) && ItemCode.Equals(priceObj.ItemCode) && UpdateTime.Equals(priceObj.UpdateTime);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"{StoreId} {ItemCode} {UpdateTime} {PriceValue} {AllowDiscount}";
        }
    }
}
