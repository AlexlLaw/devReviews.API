using Microsoft.AspNetCore.Mvc;
using devReviews.API.Models;

namespace devReviews.API.Controllers
{
    
    [ApiController]
    [Route("api/products/{productId}/productReviews")]
    public class ProductReviewController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetById(int productId, int id) {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(int productId, AddProductReviewInputModel model) {
            return CreatedAtAction (nameof(GetById), new { id = 1, productId = 2}, model);
        }
    }
}