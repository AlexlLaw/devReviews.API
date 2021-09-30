using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devReviews.API.Entity;
using devReviews.API.Models.Views;
using devReviews.API.Models;

namespace devReviews.API.Services
{
    public interface IProductService 
    {
        Task<List<ProductViewModel>> GetAllAsync();
        Task<ProductDetailsViewModel> GetByIdAsync(int id);
        Task<Product> AddAsync(AddProductInputModel model);
        Task<Boolean> UpdateAsync(int id, UpdateProductInputModel model);
    }
}