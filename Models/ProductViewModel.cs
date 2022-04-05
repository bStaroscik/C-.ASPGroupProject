using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Models
{
    public class ProductViewModel
    {
        [Display(Name = "Product ID")]
        public int Id { get; set; }
        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "You must enter a product name")]
        public string ProductName { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Required(ErrorMessage = "You must enter a price for the product")]
        public decimal Price { get; set; }
        public IFormFile Photo { get; set; }
        [Required(ErrorMessage = "The product must have a category")]
        public string Category { get; set; }
    }
}
