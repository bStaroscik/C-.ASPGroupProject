using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Models
{
    public class ReviewViewModel
    {
        public IEnumerable<Review> Reviews { get; set; }
        public IEnumerable<Reply> Replies { get; set; }
    }
}
