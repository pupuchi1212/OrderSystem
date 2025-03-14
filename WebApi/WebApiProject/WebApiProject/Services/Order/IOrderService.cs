using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiProject.ApiRepresentation;
using WebApiProject.Models;


namespace WebApiProject.Services.Order
{
    public interface IOrderService
    {
        /// <summary>
        /// 取得所有訂單
        /// </summary>
        List<OrderInfo> GetAllOrders();

        /// <summary>
        /// 取得訂單詳細資訊
        /// </summary>
        OrderPresentation GetOrder(int id);

        /// <summary>
        /// 新增訂單
        /// </summary>
        OrderInfo Add(OrderPresentation OrderData);

        /// <summary>
        /// 編輯訂單明細產品數量
        /// </summary>
        OrderDetail Edit(int id, OrderDetail OrderDtlData);

        /// <summary>
        /// 刪除
        /// </summary>
        void Delete(int id);
    }
}
