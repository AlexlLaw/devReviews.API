using System.Collections.Generic;
using devReviews.API.Entity;

namespace devReviews.API.Persistence
{
    public class DevReviewDbContext
    {
        public DevReviewDbContext() 
        {
            Products = new List<Product>();
        }

        public List<Product> Products { get; set; }
    }
}