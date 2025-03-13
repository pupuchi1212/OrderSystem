namespace WebApiProject.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApiProject.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApiProject.Models.OrderDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApiProject.Models.OrderDbContext context)
        {
            //先將產品的預設資料寫入
            context.Products.AddOrUpdate(
                p => p.ProductId,
                new Product { ProductId = 1, Name = "商品A", Price = 100 },
                new Product { ProductId = 2, Name = "商品B", Price = 200 },
                new Product { ProductId = 3, Name = "商品C", Price = 300 },
                new Product { ProductId = 4, Name = "商品D", Price = 400 }
            );
        }
    }
}
