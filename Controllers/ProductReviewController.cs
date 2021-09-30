using Microsoft.AspNetCore.Mvc;
using devReviews.API.Models;
using devReviews.API.Models.Views;
using AutoMapper;
using devReviews.API.Persistence;
using devReviews.API.Entity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using devReviews.API.Services;
using devReviews.API.Persistence.Repositorys;

namespace devReviews.API.Controllers
{

    [ApiController]
    [Route("api/products/{productId}/productReviews")]
    public class ProductReviewController : ControllerBase
    {
        private readonly IProductReviewService _IProductReviewService;

        public ProductReviewController(IProductReviewService IProductReviewService)
        {  

          _IProductReviewService = IProductReviewService;

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int productId, int id)
        {
            var productReview = await _IProductReviewService.GetReviewByIdAsync(id);

            if (productReview == null) {
                return NotFound("Review não encontrado");
            }

            return Ok(productReview);
        }

        [HttpPost]
        public async Task<IActionResult> Post(int productId, AddProductReviewInputModel model)
        {
           var product = await _IProductReviewService.AddReviewAsync(productId, model);

           return CreatedAtAction(nameof(GetById), new { id = product.Id, productId = productId }, model);
        }
    }
}