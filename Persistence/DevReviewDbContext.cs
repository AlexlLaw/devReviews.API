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
                p.Property(p => p.Title)
                    .HasMaxLength(50)
                    .IsRequired(true);
                
                p.Property(p => p.Description)
                    .HasMaxLength(255)
                    .IsRequired(true);
                 p.Property(p => p.Price)
                    .IsRequired(true);
            });

            modelBuilder.Entity<ProductReview>(pr =>  {
                pr.ToTable("tb_ProductReviews");
                pr.HasKey(p => p.Id);
                pr.Property(p => p.Author)
                    .HasMaxLength(50)
                    .IsRequired(true);
                pr.Property(p => p.Rating)
                    .HasMaxLength(10);
                pr.Property(p => p.Commets)
                    .HasMaxLength(255)
                    .IsRequired(true);
            });
        }
    }
}