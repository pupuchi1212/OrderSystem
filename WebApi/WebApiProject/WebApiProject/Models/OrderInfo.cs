using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiProject.Models
{
    public class OrderInfo
    {
        public OrderInfo()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }
        [Key]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }

        [JsonIgnore]
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}