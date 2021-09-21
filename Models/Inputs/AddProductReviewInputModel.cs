namespace devReviews.API.Models
{
    public class AddProductReviewInputModel
    {
        public string Author { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
    }
}