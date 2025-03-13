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
    }
}
