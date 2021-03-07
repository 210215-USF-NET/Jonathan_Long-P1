using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreModels;

namespace StoreDL
{
    /// <summary>
    /// This is my DB context for my customer objects
    /// </summary>
    public class StoreDBContext : DbContext
    {
        public StoreDBContext(DbContextOptions options) : base(options)
        {
        }

        protected StoreDBContext()
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Property(cust => cust.CustID).ValueGeneratedOnAdd(); //Incr custID when adding new to DB
            modelBuilder.Entity<Order>().Property(ord => ord.OrderID).ValueGeneratedOnAdd(); //Incr orderID when adding new to DB
            modelBuilder.Entity<Location>().Property(loc => loc.LocationID).ValueGeneratedOnAdd(); //Incr locationID when adding new to DB
            modelBuilder.Entity<Item>().Property(item => item.ItemID).ValueGeneratedOnAdd(); //Incr itemID when adding new to DB
            modelBuilder.Entity<ProductOrder>().Property(p => p.ProductOrderID).ValueGeneratedOnAdd(); //Incr productorderID when adding new to DB
            modelBuilder.Entity<Product>().Property(product => product.ProductID).ValueGeneratedOnAdd(); //Incr productID when adding new to DB

        }
    }
}
