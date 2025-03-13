using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiProject.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual ProductInfo ProductInfo { get; set; }
    }
}