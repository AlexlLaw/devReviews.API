using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using devReviews.API.Entity;
using Microsoft.EntityFrameworkCore;

namespace devReviews.API.Persistence.Repositorys
{
    public class ProductRepository : IProductRepository
    {
        private readonly DevReviewDbContext _DbContext;

        public ProductRepository(DevReviewDbContext dbContext)
        {
          _DbContext = dbContext;   
            
        }
        public async Task AddAsync(Product product)
        {
            await _DbContext.Products.AddAsync(product);
            await _DbContext.SaveChangesAsync();

        }

        public async Task AddReviewAsync(ProductReview productReview)
        {
           await _DbContext.ProductReviews.AddAsync(productReview);
           await _DbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
             return await _DbContext.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
           return await _DbContext.Products.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> GetDetailsByIdAsync(int id)
        {
            return await _DbContext.Products
                .Include(p => p.Reviews)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ProductReview> GetReviewByIdAsync(int id)
        {
           return await _DbContext.ProductReviews.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(Product product)
        {
           _DbContext.Products.Update(product);
           await _DbContext.SaveChangesAsync();
        }
    }
}