using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CURDOPERATION.Models
{
    public class ProductsModel
    {[Required(ErrorMessage = "Product can not be Empty")]
        public string productName { get; set; }
        [Required(ErrorMessage = "Product decription can not be Empty")]
        public string ProductDesciption { get; set; }
        [Required(ErrorMessage = "Product color can not be Empty")]
        public string ProductColor { get; set; }
        [Required(ErrorMessage = "Product price can not be Empty")]
        public int ProductListPrice { get; set; }
    }
}