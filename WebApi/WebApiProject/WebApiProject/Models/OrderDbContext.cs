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

        public DbSet<ProductInfo> ProductInfo { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}