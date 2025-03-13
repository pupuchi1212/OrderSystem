using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiProject.Models;

namespace WebApiProject.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly OrderDbContext _db;

        public ProductService(OrderDbContext context)
        {
            _db = context;
        }

        public List<ProductInfo> GetAllProducts()
        {
            return _db.ProductInfo.ToList();
        }
    }
}