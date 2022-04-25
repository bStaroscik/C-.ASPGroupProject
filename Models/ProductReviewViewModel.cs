using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Models
{
    public class ProductReviewViewModel
    {

        public IEnumerable<Review> Reviews { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
