using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;

namespace FinalLab.Entities
{
    [Table("carts")]
    public class Cart
    {
        public Cart()
        {
            Items = new Collection<Item>();
        }

        [Key, Column("username", Order = 0)]
        public string Username { get; set; }

        [Key, Column("item_code", Order = 1)]
        public string ItemCode { get; set; }

        [Column("amount")]
        public int Amount { get; set; }

        public Cart CopyCart()
        {
            Cart cart = new Cart()
            {
                ItemCode = this.ItemCode,
                Username = this.Username,
                Amount = this.Amount
            };
            return cart;
        }

        public virtual Item Item { get; set; }

        public virtual Account Account { get; set; }

        public virtual ICollection<Item> Items { get; set; }

        public double CalculateTotalCost()
        {
            double totalCost = 0;
            foreach (var item in Items)
            {
                totalCost += item.UpdatedPrice * item.QtyInPackage;
            }
            return totalCost;
        }
    }
}
