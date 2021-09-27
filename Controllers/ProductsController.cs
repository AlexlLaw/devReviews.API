using Microsoft.AspNetCore.Mvc;
using devReviews.API.Models;
using devReviews.API.Models.Views;
using devReviews.API.Persistence;
using devReviews.API.Entity;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace devReviews.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        
        private readonly DevReviewDbContext _DbContext;
        private readonly IMapper _Mapper;

        public ProductsController(DevReviewDbContext dbContext, IMapper mapper)
        {
          _DbContext = dbContext;   
          _Mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll() {
            var products = _DbContext.Products;
            var productsViewModel = _Mapper.Map<List<ProductViewModel>>(products);

            return Ok(productsViewModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var product = await _DbContext.Products
            .Include(p => p.Reviews)
            .SingleOrDefaultAsync(p => p.Id == id);

            if (product == null) {
                return NotFound();
            }

            var productDetails = _Mapper.Map<ProductDetailsViewModel>(product);

            return Ok(productDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddProductInputModel model) {
            var product = new Product(model.Title, model.Description, model.Price);

            await _DbContext.Products.AddAsync(product);
            await _DbContext.SaveChangesAsync();

            return CreatedAtAction (nameof(GetById), new { id = product.Id}, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateProductInputModel model) {
            if (model.Description.Length > 50) {
                return BadRequest();
            }

            var product = await _DbContext.Products.SingleOrDefaultAsync(p => p.Id == id);

            if (product == null) {
                return NotFound();
            }

            product.UpdateReview(model.Description, model.Price);
            await _DbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            return Ok();
        }
    }
}