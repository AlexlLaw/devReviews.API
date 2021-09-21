using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devReviews.API.Models.Views
{
    public class ProductReviewDetailsViewModel
    {
        public int Id { get; private set; }
        public string Author { get; private set; }
        public int Rating { get; private set; }
        public DateTime RegisterAt { get; private set; }
        public string Commets { get; private set; }
    }
}