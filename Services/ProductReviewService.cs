using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devReviews.API.Services;
using AutoMapper;
using devReviews.API.Persistence.Repositorys;
using devReviews.API.Entity;
using devReviews.API.Models.Views;
using devReviews.API.Models;

namespace devReviews.API.Services
{
    public class ProductReviewService : IProductReviewService
    {
        private readonly IMapper _Mapper;
        private readonly IProductRepository _ProductRepository;

        public ProductReviewService(IProductRepository IProductRepository, IMapper mapper) {  
          _ProductRepository = IProductRepository;
          _Mapper = mapper;
        }

        public async Task<ProductReviewDetailsViewModel> GetReviewByIdAsync(int id) {
            var productReview = await _ProductRepository.GetReviewByIdAsync(id);
            var productDetails = _Mapper.Map<ProductReviewDetailsViewModel>(productReview);

            return productDetails;
        }

        public async Task<ProductReview> AddReviewAsync(int productId, AddProductReviewInputModel model) {
            var productReview = new ProductReview(model.Author, model.Rating, model.Comments, productId);
            await _ProductRepository.AddReviewAsync(productReview);

            return productReview;
        }
    }
}