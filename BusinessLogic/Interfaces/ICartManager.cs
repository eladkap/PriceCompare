using FinalLab.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalLab.Interfaces
{
    interface ICartManager
    {
        void AddItemToCart(Cart cart, Item item);

        void RemoveItemFromCart(Cart cart, Item item);

        bool CartContainsItem(Cart cart, Item item);

        void ClearCart(Cart cart);

        void IncrementItemUnitToCart(Cart cart, Item item);

        void DecrementItemUnitToCart(Cart cart, Item item);

        int GetCartItemAmount(Cart cart, Item item);

        void SaveCartInDatabase(Cart cart);

        Cart LoadCartFromDatabase(Account account);

        double CalculateCartTotalCost(Cart cart, Store store);

        void RemoveCartRecordsByUsername(string username); 
    }
}
