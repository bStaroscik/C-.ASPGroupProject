using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Models
{
    public class Review
    {
        [ForeignKey("ProductID")]
        public int? ProductID { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "You must enter a user name")]
        [Display(Name = "User Name")]
        public string User { get; set; }
        [Required(ErrorMessage = "You must enter a product review")]
        [Display(Name = "Product Review")]
        public string ReviewText{ get; set; }
        [Required(ErrorMessage = "You must enter a product rating")]
        [Display(Name = "Product Rating")]
        [Range(1,5)]
        public int Rating { get; set; }

    }
}
