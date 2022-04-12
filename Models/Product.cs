using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Models
{
    public class Product
    {
        [Display(Name = "Product ID")]
        public int? Id { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price { get; set; }
        [Display(Name = "Image Name")]
        public string ImageName { get; set; }
        public string Category { get; set; }

    }
}
