using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiProject.Models;
using WebApiProject.Services.Product;

namespace WebApiProject.Api
{
    public class ProductsController : ApiController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// 取得產品清單
        /// </summary>
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_productService.GetAllProducts());
        }

        /// <summary>
        /// 取得產品詳細資訊
        /// </summary>
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(_productService.GetProduct(id));
        }

        /// <summary>
        /// 新增
        /// </summary>
        [HttpPost]
        public IHttpActionResult Post([FromBody] ProductInfo ProData)
        {
            return Ok(_productService.Add(ProData));
        }

        /// <summary>
        /// 編輯
        /// </summary>
        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody] ProductInfo ProData)
        {
            _productService.Edit(id, ProData);
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }

        /// <summary>
        /// 刪除
        /// </summary>
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            _productService.Delete(id);
            return new HttpResponseMessage(System.Net.HttpStatusCode.NoContent);
        }
    }
}