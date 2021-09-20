using System.Collections.Generic;
using System;

namespace devReviews.API.Entity
{
    public class Product
    {
        public Product(string title, string description, decimal price) 
        {
            this.Title = title;
            this.Description = description;
            this.Price = price;
            this.RegisterAt = DateTime.Now;
            this.Reviews = new List<ProductReview>();
        }
        
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public DateTime RegisterAt { get; private set; }
        public List<ProductReview> Reviews { get; private set; }

        public void AddReview(ProductReview review) {
            Reviews.Add(review);
        }

        public void UpdateReview(string description, decimal price)
        {
            Description = description;
            Price = price;
        }
    }
}