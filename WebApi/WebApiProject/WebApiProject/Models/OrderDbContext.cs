using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApiProject.Models
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext() : base("OrderDbContext") { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}