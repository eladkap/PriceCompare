using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalLab.Entities;
using FinalLab.Interfaces;
using FinalLab.Engines;

namespace FinalLab.Managers
{
    public class CartManager : ICartManager
    {
        private CartEngine cartEngine;

        public CartManager()
        {
            cartEngine = new CartEngine();
        }

        public void AddItemToCart(Cart cart, Item item)
        {
            cartEngine.AddItemToCart(cart, item);
        }

        public void RemoveItemFromCart(Cart cart, Item item)
        {
            cartEngine.RemoveItemFromCart(cart, item);
        }

        public bool CartContainsItem(Cart cart, Item item)
        {
            return cartEngine.CartContainsItem(cart, item);
        }

        public double CalculateCartTotalCost(Cart cart, Store store)
        {
            return cartEngine.CalculateCartTotalCost(cart, store);
        }

        public void ClearCart(Cart cart)
        {
            cartEngine.ClearCart(cart);
        }

        public void IncrementItemUnitToCart(Cart cart, Item item)
        {
            cartEngine.IncrementItemUnitToCart(cart, item);
        }

        public void DecrementItemUnitToCart(Cart cart, Item item)
        {
            cartEngine.DecrementItemUnitToCart(cart, item);
        }

        public ICollection GetCartDetails(Cart cart)
        {
            return cartEngine.GetCartDetails(cart);
        }

        public int GetCartItemAmount(Cart cart, Item item)
        {
            return cartEngine.GetCartItemAmount(cart, item);
        }

        public Cart LoadCartFromDatabase(Account account)
        {
            return cartEngine.LoadCartFromDatabase(account);
        }

        public void SaveCartInDatabase(Cart cart)
        {
            cartEngine.SaveCartInDatabase(cart);
        }

        public void RemoveCartRecordsByUsername(string username)
        {
            cartEngine.RemoveCartRecordsByUsername(username);
        }
    }
}
