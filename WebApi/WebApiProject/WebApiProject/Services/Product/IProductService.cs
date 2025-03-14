using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiProject.Models;


namespace WebApiProject.Services.Product
{
    public interface IProductService
    {
        /// <summary>
        /// 取得所有產品資訊
        /// </summary>
        List<ProductInfo> GetAllProducts();

        /// <summary>
        /// 取得產品詳細資訊
        /// </summary>
        ProductInfo GetProduct(int id);

        /// <summary>
        /// 新增產品
        /// </summary>
        ProductInfo Add(ProductInfo productData);

        /// <summary>
        /// 編輯產品
        /// </summary>
        ProductInfo Edit(int id, ProductInfo productData);

        /// <summary>
        /// 刪除
        /// </summary>
        void Delete(int id);
    }
}
