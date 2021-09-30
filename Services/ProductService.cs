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
    public class ProductService : IProductService
    {
        private readonly IMapper _Mapper;
        private readonly IProductRepository _ProductRepository;

        public ProductService(IProductRepository IProductRepository, IMapper mapper) {  
          _ProductRepository = IProductRepository;
          _Mapper = mapper;
        }

        public async Task<List<ProductViewModel>> GetAllAsync() {
          var product = await _ProductRepository.GetAllAsync();
          var productsViewModel = _Mapper.Map<List<ProductViewModel>>(product);

          return productsViewModel;
        }

        public async Task<ProductDetailsViewModel> GetByIdAsync(int id) {
          var product = await _ProductRepository.GetByIdAsync(id);
          var productDetails = _Mapper.Map<ProductDetailsViewModel>(product);
          
          return productDetails;
        }

        public async  Task<Product> AddAsync(AddProductInputModel model) {
          var product = new Product(model.Title, model.Description, model.Price);
          await _ProductRepository.AddAsync(product);

          return product;
        }

        public async Task<Boolean> UpdateAsync(int id, UpdateProductInputModel model) {
          var product = await _ProductRepository.GetByIdAsync(id);

           if (product == null) {
                return false;
            }

          product.UpdateReview(model.Description, model.Price);
          await _ProductRepository.UpdateAsync(product);

          return true;
        }

    }
}