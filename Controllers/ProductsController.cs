using System.Reflection.Emit;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using devReviews.API.Models;
using devReviews.API.Models.Views;
using devReviews.API.Persistence;
using devReviews.API.Entity;
using System.Linq;

namespace devReviews.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        
        private readonly DevReviewDbContext _DbContext;

        public ProductsController(DevReviewDbContext dbContext)
        {
          _DbContext = dbContext;   
        }

        [HttpGet]
        public IActionResult GetAll() {
            var products = _DbContext.Products;

            var productsViewModel = products.Select(p => new ProductViewModel(p.Id, p.Title, p.Price));

            return Ok(productsViewModel);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            var product = _DbContext.Products.SingleOrDefault(p => p.Id == id);

            if (product == null) {
                return NotFound();
            }

            var reviewViewModel = product
            .Reviews
            .Select(p => new ProductReviewViewModel(p.Id, p.Author, p.Rating, p.RegisterAt, p.Commets))
            .ToList();

            var productDetails = new ProductDetailsViewModel(
            product.Id,
            product.Title,
            product. Description,
            product. Price,
            product.RegisterAt
            );

            return Ok(productDetails);
        }

        [HttpPost]
        public IActionResult Post(AddProductInputModel model) {
            var product = new Product(model.Title, model.Description, model.Price);

            _DbContext.Products.Add(product);

            return CreatedAtAction (nameof(GetById), new { id = product.Id}, model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateProductInputModel model) {
            if (model.Description.Length > 50) {
                return BadRequest();
            }

            var product = _DbContext.Products.SingleOrDefault(p => p.Id == id);

            if (product == null) {
                return NotFound();
            }

            product.UpdateReview(model.Description, model.Price);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            return Ok();
        }
    }
}