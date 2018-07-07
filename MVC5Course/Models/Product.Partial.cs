namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ProductMetaData))]
    public partial class Product
    {
    }
    
    public partial class ProductMetaData
    {
        [Required(ErrorMessage = "商品名稱必填")]
        [StringLength(50, ErrorMessage = "長度不可超過{1}個字")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "價錢必填")]
        [Range(200, Int32.MaxValue, ErrorMessage = "價錢至少大於{1}")]
        [DisplayFormat(DataFormatString = "{0:#}")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "啟用必填")]
        public bool? Active { get; set; }

        [Required(ErrorMessage = "庫存必填")]
        public decimal? Stock { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
    
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
