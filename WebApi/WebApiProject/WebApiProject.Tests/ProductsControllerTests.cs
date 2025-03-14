using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using WebApiProject.Api;
using WebApiProject.Models;
using WebApiProject.Services.Product;
using Xunit;

namespace WebApiProject.Tests
{
    public class ProductsControllerTests
    {
        private readonly Mock<IProductService> _mockProductService;
        private readonly ProductsController _controller;

        public ProductsControllerTests()
        {
            // 建立 IProductService 模擬對象
            _mockProductService = new Mock<IProductService>();

            // 注入模擬的 IProductService
            _controller = new ProductsController(_mockProductService.Object);
        }

        [Fact]
        public void GetProducts_ShouldReturn_AllProducts()
        {
            //模擬回傳資料
            var products = new List<ProductInfo>
            {
                new ProductInfo { ProductId = 1, Name = "Product A", Price = 100 },
                new ProductInfo { ProductId = 2, Name = "Product B", Price = 200 }
            };
            _mockProductService.Setup(service => service.GetAllProducts()).Returns(products);

            //呼叫 API
            IHttpActionResult actionResult = _controller.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<List<ProductInfo>>;

            //確保回傳的內容正確
            Xunit.Assert.NotNull(contentResult);
            Xunit.Assert.Equal(2, contentResult.Content.Count);
            Xunit.Assert.Equal("Product A", contentResult.Content[0].Name);
        }

        [Fact]
        public void PostProduct_ShouldReturn_CreatedProduct()
        {
            // Arrange
            var newProduct = new ProductInfo { Name = "Product D", Price = 300 };

            _mockProductService.Setup(service => service.Add(It.IsAny<ProductInfo>()))
                               .Returns((ProductInfo p) => { p.ProductId = 999; return p; });

            // Act
            IHttpActionResult actionResult = _controller.Post(newProduct);

            var okResult = actionResult as OkNegotiatedContentResult<ProductInfo>;

            // Assert
            Xunit.Assert.NotNull(okResult); // 確保不是 null
            Xunit.Assert.NotNull(okResult.Content); // 確保回傳的內容存在
            Xunit.Assert.Equal("Product D", okResult.Content.Name);
        }
    }
}
