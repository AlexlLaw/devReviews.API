using System.Collections.Generic;
using devReviews.API.Entity;
using Microsoft.EntityFrameworkCore;

namespace devReviews.API.Persistence
{
    public class DevReviewDbContext : DbContext
    {
        public DevReviewDbContext(DbContextOptions<DevReviewDbContext> options) : base(options) 
        {
            Products = new List<Product>();
        }

        public DbSet<Product> Products { get; set; }
        public Dbset<ProductReview> ProductReview { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {

        }


    }
}