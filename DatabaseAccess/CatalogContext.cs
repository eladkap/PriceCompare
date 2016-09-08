using FinalLab.Entities;
using System.Data.Entity;

namespace FinalLab
{

    public class CatalogContext : DbContext
    {
        public DbSet<Chain> Chains { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Price> Prices { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Cart> Carts { get; set; }
    }

}