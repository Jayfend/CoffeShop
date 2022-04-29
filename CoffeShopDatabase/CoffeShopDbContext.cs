using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CoffeShopDatabase
{
    public partial class CoffeShopDbContext : DbContext
    {
        public CoffeShopDbContext()
            : base("name=CoffeShopDbContext")
        {
        }

     
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }  
    }
}
