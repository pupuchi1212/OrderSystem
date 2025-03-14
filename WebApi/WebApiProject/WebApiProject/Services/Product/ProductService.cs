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

        public ProductInfo GetProduct(int id)
        {
            return _db.ProductInfo.Find(id);
        }

        public ProductInfo Add(ProductInfo productData)
        {
            //判斷是否有相同名稱的產品
            ChenkName(productData.Name);

            ProductInfo newProduct = new ProductInfo()
            {
                Name = productData.Name,
                Price = productData.Price
            };
            _db.ProductInfo.Add(newProduct);
            _db.SaveChanges();

            return newProduct;
        }

        public ProductInfo Edit(int id, ProductInfo productData)
        {
            ProductInfo data = GetProduct(id);
            if (data == null)
            {
                throw new Exception("資料錯誤");
            }
            
            //只編輯價格
            data.Price = productData.Price;
            _db.SaveChanges();

            return data;
        }

        public void Delete(int id)
        {
            ProductInfo data = GetProduct(id);
            _db.ProductInfo.Remove(data);
            _db.SaveChanges();
        }

        private void ChenkName(string ProName)
        {
            bool result = true;
            ProductInfo check = _db.ProductInfo.Where(x => x.Name == ProName).FirstOrDefault();
            if (check != null)
            {
                //產品名稱應不能重複
                throw new Exception("產品名稱重複！");
            }
        }
    }
}