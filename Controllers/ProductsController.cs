using Microsoft.AspNetCore.Mvc;
using devReviews.API.Models;
using devReviews.API.Models.Views;
using devReviews.API.Entity;
using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;
using devReviews.API.Persistence.Repositorys;
using devReviews.API.Services;

namespace devReviews.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _IProductService;

        public ProductsController(IProductService IProductService) {  
          _IProductService = IProductService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var products = await _IProductService.GetAllAsync();
            
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var product = await _IProductService.GetByIdAsync(id);

            if (product == null) {
                return NotFound("Produto não encontrado");
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddProductInputModel model) {
            var product = await _IProductService.AddAsync(model);

            return CreatedAtAction (nameof(GetById), new { id = product.Id}, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateProductInputModel model) {
            var product = await  _IProductService.UpdateAsync(id, model);

            if (!product) {
                return NotFound("Produto não encontrado");
            }
           
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            return Ok();
        }
    }
}