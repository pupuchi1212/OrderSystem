using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiProject.ApiRepresentation;
using WebApiProject.Models;

namespace WebApiProject.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly OrderDbContext _db;

        public OrderService(OrderDbContext context)
        {
            _db = context;
        }

        public List<OrderInfo> GetAllOrders()
        {
            return _db.OrderInfo.ToList();
        }

        public OrderPresentation GetOrder(int id)
        {
            OrderPresentation data = _db.OrderInfo.Where(x => x.OrderId == id)
                                     .Select(x => new OrderPresentation
                                     {
                                         OrderId = x.OrderId,
                                         UserId = x.UserId,
                                         OrderDate = x.OrderDate,
                                         OrderDetails = x.OrderDetail.ToList()
                                     }).FirstOrDefault();
            return data;
        }

        public OrderInfo Add(OrderPresentation OrderData)
        {
            OrderInfo newOrder = new OrderInfo()
            {
                UserId = OrderData.UserId,
                OrderDate = DateTime.Now,

            };

            foreach (OrderDetail tmp in OrderData.OrderDetails)
            {
                OrderDetail orgDtl = new OrderDetail
                {
                    ProductId = tmp.ProductId,
                    ProdCount = tmp.ProdCount
                };
                newOrder.OrderDetail.Add(orgDtl);
            }
            _db.OrderInfo.Add(newOrder);
            _db.SaveChanges();

            return newOrder;
        }

        public OrderDetail Edit(int id, OrderDetail OrderDtlData)
        {
            OrderDetail data = _db.OrderDetail.Where(x => x.OrderId == id && x.ProductId == OrderDtlData.ProductId).FirstOrDefault();
            if (data == null)
            {
                throw new Exception("資料錯誤");
            }
            data.ProdCount = OrderDtlData.ProdCount;
            _db.SaveChanges();
            return data;
        }

        public void Delete(int id)
        {
            OrderInfo data = _db.OrderInfo.Find(id);
            _db.OrderDetail.RemoveRange(data.OrderDetail);
            _db.OrderInfo.Remove(data);
            _db.SaveChanges();
        }
    }
}