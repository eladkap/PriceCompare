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
        public float price { get; set; }

        [Column("allow_discount")]
        public bool AllowDiscount { get; set; }

        public virtual Store Store { get; set; }

        public virtual Item Item { get; set; }

        public override bool Equals(object obj)
        {
            Price priceObj = (Price)obj;
            return Store.Equals(priceObj.Store) && Item.Equals(priceObj.Item) && UpdateTime.Equals(priceObj.UpdateTime);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
