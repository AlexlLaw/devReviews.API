using System.Collections.Generic;
using System.Threading.Tasks;
using devReviews.API.Entity;

namespace devReviews.API.Persistence.Repositorys
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task<Product> GetDetailsByIdAsync(int id);
        Task<Product> GetByIdAsync(int id);
        Task<List<Product>> GetAllAsync();
        Task UpdateAsync(Product product);

        Task<ProductReview> GetReviewByIdAsync(int id);
        Task AddReviewAsync(ProductReview productReview);
        
    }
}