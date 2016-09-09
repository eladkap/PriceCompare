using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalLab
{
    [Table("stores")]
    public class Store
    {
        public Store()
        {
            Items = new List<Item>();
        }

        [Key, Column("store_id")]
        public string StoreId { get; set; }

        [Column("chain_id")]
        public string ChainId { get; set; }

        [Column("store_name")]
        public string StoreName { get; set; }

        [Column("subchain_name")]
        public string SubchainName { get; set; }

        [Column("bikoret_no")]
        public int BikoretNo { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("city")]
        public string City { get; set; }

        [Column("zip_code")]
        public string Zipcode { get; set; }

        [Column("last_update_date")]
        public string LastUpdateDate { get; set; }

        [Column("last_update_time")]
        public string LastUpdateTime { get; set; }

        public virtual Chain Chain { get; set; }

        public virtual ICollection<Item> Items { get; set; }

        public override bool Equals(object obj)
        {
            Store storeObj = (Store)obj;
            return StoreId.Equals(storeObj.StoreId);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"{StoreId} {StoreName} {ChainId} {SubchainName} {BikoretNo} {City} {Address} {Zipcode}";
        }
    }
}
