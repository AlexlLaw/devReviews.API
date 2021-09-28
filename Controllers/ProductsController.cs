using Microsoft.AspNetCore.Mvc;
using devReviews.API.Models;
using devReviews.API.Models.Views;
using devReviews.API.Entity;
using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;
using devReviews.API.Persistence.Repositorys;

namespace devReviews.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        
        private readonly IMapper _Mapper;
        private readonly IProductRepository _IProductRepository;

        public ProductsController(IProductRepository IProductRepository, IMapper mapper)
        {  
          _IProductRepository = IProductRepository;
          _Mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
        
            var products = await _IProductRepository.GetAllAsync();
            var productsViewModel = _Mapper.Map<List<ProductViewModel>>(products);

            return Ok(productsViewModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var product = await _IProductRepository.GetByIdAsync(id);

            if (product == null) {
                return NotFound();
            }

            var productDetails = _Mapper.Map<ProductDetailsViewModel>(product);

            return Ok(productDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddProductInputModel model) {
            var product = new Product(model.Title, model.Description, model.Price);

            await  _IProductRepository.AddAsync(product);

            return CreatedAtAction (nameof(GetById), new { id = product.Id}, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateProductInputModel model) {
            if (model.Description.Length > 50) {
                return BadRequest();
            }

            var product = await _IProductRepository.GetByIdAsync(id);

            if (product == null) {
                return NotFound();
            }
            product.UpdateReview(model.Description, model.Price);
            await _IProductRepository.UpdateAsync(product);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            return Ok();
        }
    }
}