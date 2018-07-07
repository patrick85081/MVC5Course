using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.ViewModels
{
    public class ProductViewModel
    {
        [Display(Name = "商品編號")]
        public int ProductId { get; set; }

        [Display(Name = "商品名稱")]
        [Required(ErrorMessage = "商品名稱必填")]
        [StringLength(50, ErrorMessage = "長度不可超過{1}個字")]
        public string ProductName { get; set; }

        [Display(Name = "售價")]
        [Required(ErrorMessage = "價錢必填")]
        [Range(200, Int32.MaxValue, ErrorMessage = "價錢至少大於{1}")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal? Price { get; set; }

        [Display(Name = "庫存量")]
        [Required(ErrorMessage = "庫存必填")]
        [DisplayFormat(DataFormatString = "{0:N1}")]
        public decimal? Stock { get; set; }
    }
}