using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "商品名稱必填")]
        [StringLength(50, ErrorMessage = "長度不可超過{1}個字")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "價錢必填")]
        [Range(500, Int32.MaxValue, ErrorMessage = "價錢至少大於{1}")]
        [DisplayFormat(DataFormatString = "{0:#}")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "股價必填")]
        public decimal? Stock { get; set; }
    }
}