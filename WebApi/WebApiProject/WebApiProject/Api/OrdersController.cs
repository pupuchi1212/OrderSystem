using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiProject.ApiRepresentation;
using WebApiProject.Models;
using WebApiProject.Services.Order;

namespace WebApiProject.Api
{
    public class OrdersController : ApiController
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// 取得訂單清單
        /// </summary>
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_orderService.GetAllOrders());
        }

        /// <summary>
        /// 取得訂單詳細資訊
        /// </summary>
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(_orderService.GetOrder(id));
        }

        /// <summary>
        /// 新增
        /// </summary>
        [HttpPost]
        public IHttpActionResult Post([FromBody] OrderPresentation OrdData)
        {
            return Ok(_orderService.Add(OrdData));
        }

        /// <summary>
        /// 編輯數量
        /// </summary>
        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody] OrderDetail OrdDtlData)
        {
            _orderService.Edit(id, OrdDtlData);
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }

        /// <summary>
        /// 刪除
        /// </summary>
        public HttpResponseMessage Delete(int id)
        {
            _orderService.Delete(id);
            return new HttpResponseMessage(System.Net.HttpStatusCode.NoContent);
        }
    }
}