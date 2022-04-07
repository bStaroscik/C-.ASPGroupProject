using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Models
{
    public class Customer
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "You must enter a user name")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "You must enter a first name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "You must enter a last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "You must enter an address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "You must enter an email")]
        public string Email { get; set; }
    }
}
