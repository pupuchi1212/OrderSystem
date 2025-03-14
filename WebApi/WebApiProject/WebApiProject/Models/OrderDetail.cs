using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApiProject.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int ProdCount { get; set; }

        [JsonIgnore]
        [ForeignKey("ProductId")]
        public virtual ProductInfo ProductInfo { get; set; }

        [JsonIgnore]
        [ForeignKey("OrderId")]
        public virtual OrderInfo OrderInfo { get; set; }

    }
}