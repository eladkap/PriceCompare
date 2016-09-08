using FinalLab.Entities;
using System;
using System.Collections;
using System.Linq;

namespace FinalLab.Engines
{
    public class CartEngine
    {
        public void AddItemToCart(Cart cart, Item item)
        {
            item.QtyInPackage = 1;
            cart.Items.Add(item);
        }

        public void RemoveItemFromCart(Cart cart, Item item)
        {
            cart.Items.Remove(item);
        }

        public bool CartContainsItem(Cart cart, Item item)
        {
            return cart.Items.Contains(item);
        }

        public double CalculateCartTotalCost(Cart cart, Store store)
        {
            double totalCost = 0;
            foreach (Item item in cart.Items)
            {
                totalCost += item.UpdatedPrice * item.QtyInPackage;
            }
            return totalCost;
        }

        public void ClearCart(Cart cart)
        {
            cart.Items.Clear();
        }

        public void IncrementItemUnitToCart(Cart cart, Item item)
        {
            foreach (Item _item in cart.Items)
            {
                if (item.ItemCode.Equals(_item.ItemCode))
                {
                    _item.QtyInPackage++;
                }
            }
        }

        public void DecrementItemUnitToCart(Cart cart, Item item)
        {
            foreach (Item _item in cart.Items)
            {
                if (item.ItemCode.Equals(_item.ItemCode) && _item.QtyInPackage > 0)
                {
                    _item.QtyInPackage--;
                }
            }
        }

        // check if necassary
        public ICollection GetCartDetails(Cart cart)
        {
            throw new NotImplementedException();
        }

        public int GetCartItemAmount(Cart cart, Item item)
        {
            foreach (Item _item in cart.Items)
            {
                if (item.ItemCode.Equals(_item.ItemCode))
                {
                    return _item.QtyInPackage;
                }
            }
            return -1;
        } 

        public Cart LoadCartFromDatabase(Account account)
        {
            using (CatalogContext context = new CatalogContext())
            {
                var cartItems = from cartItem in context.Carts
                                where cartItem.Account.Username.Equals(account.Username)
                                select cartItem;
                if (cartItems.Count() == 0)
                {
                    return null;
                }
                Cart cart = new Cart()
                {
                    Username = account.Username
                };
                foreach (var cartItem in cartItems)
                {
                    Item item = new Item()
                    {
                        ItemCode = cartItem.ItemCode,
                        QtyInPackage = cartItem.Amount
                    };
                    cart.Items.Add(item);
                }
                return cart;
            }
        }

        public void SaveCartInDatabase(Cart cart)
        {
            using (CatalogContext context = new CatalogContext())
            {
                foreach (var item in cart.Items)
                {
                    Cart cartItem = cart.CopyCart();
                    cartItem.ItemCode = item.ItemCode;
                    cartItem.Amount = item.QtyInPackage;
                    context.Carts.Add(cartItem);
                }
                context.SaveChanges();
            }
        }

        internal void RemoveCartRecordsByUsername(string username) // has bug while trying to save another cart of the same user
        {
            using (CatalogContext context = new CatalogContext())
            {
                var cartRecords = from cartRecord in context.Carts
                                  where cartRecord.Username.Equals(username)
                                  select cartRecord;
                context.Carts.RemoveRange(cartRecords);
                context.SaveChanges();
            }
        }
    }
}
