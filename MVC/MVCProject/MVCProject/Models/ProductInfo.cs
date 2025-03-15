using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class ProductInfo
    {
        [Key]
        [Display(Name = "產品編號")]
        public int ProductId { get; set; }
        [Display(Name = "名稱")]
        public string Name { get; set; }
        [Display(Name = "價格")]
        public decimal Price { get; set; }
    }
}