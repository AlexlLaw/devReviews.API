using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devReviews.API.Entity;
using devReviews.API.Models.Views;
using devReviews.API.Models;


namespace devReviews.API.Services
{
    public interface IProductReviewService
    {
        Task<ProductReviewDetailsViewModel> GetReviewByIdAsync(int id);
        Task<ProductReview> AddReviewAsync(int productId, AddProductReviewInputModel model);
    }
}