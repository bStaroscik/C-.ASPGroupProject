using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Models
{
    public class Reply
    {


        public int? ReviewID { get; set; }
        public int? ProductID { get; set; }
            public int Id { get; set; }
        
        [Required(ErrorMessage = "You must enter a user name")]
            [Display(Name = "User Name")]
            public string User { get; set; }
            
        
        [Required(ErrorMessage = "You must enter a reply to the review")]
            [Display(Name = "Reply to review")]
            public string ReplyText { get; set; }


        }
    }


