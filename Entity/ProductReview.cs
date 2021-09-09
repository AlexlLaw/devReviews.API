using System;
namespace devReviews.API.Entity
{
    public class ProductReview
    {
        public ProductReview(int id, string author, string rating, DateTime registerAt, string commets, int productId) 
        {
            this.Id = id;
            this.Author = author;
            this.Rating = rating;
            this.RegisterAt = DateTime.Now;
            this.Commets = commets;
            this.ProductId = productId; 
        }

        public int Id { get; private set; }
        public string Author { get; private set; }
        public string Rating { get; private set; }
        public DateTime RegisterAt { get; private set; }
        public string Commets { get; private set; }
        public int ProductId { get; private set; }
    }
}