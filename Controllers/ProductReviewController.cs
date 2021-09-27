using Microsoft.AspNetCore.Mvc;
using devReviews.API.Models;
using devReviews.API.Models.Views;
using AutoMapper;
using devReviews.API.Persistence;
using devReviews.API.Entity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace devReviews.API.Controllers
{

    [ApiController]
    [Route("api/products/{productId}/productReviews")]
    public class ProductReviewController : ControllerBase
    {
        private readonly DevReviewDbContext _DbContext;
        private readonly IMapper _Mapper;
        public ProductReviewController(DevReviewDbContext dbContext, IMapper mapper)
        {
          _DbContext = dbContext;   
          _Mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int productId, int id)
        {
            var productReview = await _DbContext.ProductReviews.SingleOrDefaultAsync(p => p.Id == id);

            if (productReview == null) {
                return NotFound();
            }

            var productDetails = _Mapper.Map<ProductReviewDetailsViewModel>(productReview);

            return Ok(productDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Post(int productId, AddProductReviewInputModel model)
        {
           var productReview = new ProductReview(model.Author, model.Rating, model.Comments, productId);

           await _DbContext.ProductReviews.AddAsync(productReview);
           await _DbContext.SaveChangesAsync();

           return CreatedAtAction(nameof(GetById), new { id = 1, productId = 2 }, model);
        }
    }
}