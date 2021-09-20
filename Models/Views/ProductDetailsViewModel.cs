
using devReviews.API.Models.Views;
using System.Collections.Generic;
using System;

namespace devReviews.API.Models.Views
{
    public class ProductDetailsViewModel
    { 
        public ProductDetailsViewModel(int id, string title, string description, decimal price, DateTime registerAt) 
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
            RegisterAt = registerAt;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public DateTime RegisterAt { get; private set; }
        public List<ProductReviewViewModel> Reviews { get; private set; }
    }
}