using System;
namespace devReviews.API.Entity
{
    public class ProductReview
    {
        public ProductReview(string author, int rating, string commets, int productId) 
        {
           Id = Id;
           Author = author;
           Rating = rating;
           RegisterAt = DateTime.Now;
           Commets = commets;
           ProductId = productId; 
        }

        public int Id { get; private set; }
        public string Author { get; private set; }
        public int Rating { get; private set; }
        public DateTime RegisterAt { get; private set; }
        public string Commets { get; private set; }
        public int ProductId { get; private set; }
    }
}