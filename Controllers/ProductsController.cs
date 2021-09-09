using Microsoft.AspNetCore.Mvc;
using devReviews.API.Models;

namespace devReviews.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        
        public DevReviewDbContext _DbContext { get; }

        public ProductsController(DevReviewDbContext dbContext)
        {
          _DbContext = dbContext;   
        }

        [HttpGet]
        public IActionResult GetAll() {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(AddProductInputModel model) {
            return CreatedAtAction (nameof(GetById), new { id = 1}, model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateProductInputModel model) {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            return Ok();
        }
    }
}