using System.Collections.Generic;
using System;

namespace devReviews.API.Models.Views
{
    public class ProductReviewViewModel
    {
        public ProductReviewViewModel(int id, string author, int rating, DateTime registerAt, string commets) 
        {
           Id = id;
           Author = author;
           Rating = rating;
           RegisterAt = registerAt;
           Commets = commets;   
        }

        public int Id { get; private set; }
        public string Author { get; private set; }
        public int Rating { get; private set; }
        public DateTime RegisterAt { get; private set; }
        public string Commets { get; private set; }
    }
}