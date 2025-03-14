using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiProject.Models;

namespace WebApiProject.ApiRepresentation
{
    public class OrderPresentation
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}