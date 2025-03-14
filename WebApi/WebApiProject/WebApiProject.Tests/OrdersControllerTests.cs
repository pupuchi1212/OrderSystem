using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using WebApiProject.Api;
using WebApiProject.Models;
using WebApiProject.Services.Order;
using Xunit;

namespace WebApiProject.Tests
{
    public class OrdersControllerTests
    {
        private readonly Mock<IOrderService> _mockOrderService;
        private readonly OrdersController _controller;

        public OrdersControllerTests()
        {
            // 建立 IProductService 模擬對象
            _mockOrderService = new Mock<IOrderService>();

            // 注入模擬的 IProductService
            _controller = new OrdersController(_mockOrderService.Object);
        }

        [Fact]
        public void GetOrders_ShouldReturn_AllOrders()
        {
            //模擬回傳資料
            var orderDtl = new List<OrderDetail>
            {
                new OrderDetail { Id = 1, OrderId = 1, ProductId = 2, ProdCount = 999 }
            };
            var orderInfo = new List<OrderInfo>
            {
                new OrderInfo { OrderId = 1, UserId = 1, OrderDate = DateTime.Now, OrderDetail = orderDtl }
            };
            _mockOrderService.Setup(service => service.GetAllOrders()).Returns(orderInfo);

            //呼叫 API
            IHttpActionResult actionResult = _controller.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<List<OrderInfo>>;

            //確保回傳的內容正確
            Xunit.Assert.NotNull(contentResult);
            Xunit.Assert.Equal(1, contentResult.Content.Count);
            Xunit.Assert.Equal(1, contentResult.Content[0].UserId);
        }
    }
}
