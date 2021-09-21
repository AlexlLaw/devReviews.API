using Microsoft.AspNetCore.Mvc;
using devReviews.API.Models;
using devReviews.API.Models.Views;
using devReviews.API.Persistence;
using devReviews.API.Entity;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult GetById(int id) {
            var product = _DbContext.Products
            .Include(p => p.Reviews)
            .SingleOrDefault(p => p.Id == id);

            if (product == null) {
                return NotFound();
            }

            var productDetails = _Mapper.Map<ProductDetailsViewModel>(product);

            return Ok(productDetails);
        }

        [HttpPost]
        public IActionResult Post(AddProductInputModel model) {
            var product = new Product(model.Title, model.Description, model.Price);

            _DbContext.Products.Add(product);
            _DbContext.SaveChanges();

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
            _DbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            return Ok();
        }
    }
}