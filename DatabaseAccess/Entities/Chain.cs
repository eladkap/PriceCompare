using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace FinalLab
{
    [Table("chains")]
    public class Chain
    {
        public Chain()
        {
            Stores = new List<Store>();
        }

        [Key, Column("chain_id")]
        public string ChainId { get; set; }

        [Column("chain_name")]
        public string ChainName { get; set; }

        [Column("chain_name_hebrew")]
        public string ChainNameHebrew { get; set; }

        public virtual ICollection<Store> Stores { get; set; }

        public override bool Equals(object chainObj)
        {
            Chain chain = (Chain)chainObj;
            return base.Equals(chain.ChainId.Equals(ChainId) && chain.ChainName.Equals(ChainName));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}