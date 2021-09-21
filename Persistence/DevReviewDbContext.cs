using System.Collections.Generic;
using devReviews.API.Entity;
using Microsoft.EntityFrameworkCore;

namespace devReviews.API.Persistence
{
    public class DevReviewDbContext : DbContext
    {
        public DevReviewDbContext(DbContextOptions<DevReviewDbContext> options) : base(options) 
        {
          
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Product>(p => {
                p.ToTable("tb_Product");
                p.HasKey(p => p.Id);
                p.HasMany(pp => pp.Reviews)
                    .WithOne()
                    .HasForeignKey(r => r.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ProductReview>(pr =>  {
                pr.ToTable("tb_ProductReviews");
                pr.HasKey(p => p.Id);
                pr.Property(p => p.Author)
                    .HasMaxLength(50);
            });
        }
    }
}