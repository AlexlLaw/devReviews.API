using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using devReviews.API.Services;
using Microsoft.AspNetCore.Hosting;
using devReviews.API.Persistence.Repositorys;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.AspNetCore;
using devReviews.API.Models;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

namespace devReviews.API.Extensions
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddRepositorys(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductReviewService, ProductReviewService>();

            return services;
        }

       public static IServiceCollection AddValidator(this IServiceCollection services)
       {
           services.AddControllers()
                .AddFluentValidation(Config => {
                Config.RegisterValidatorsFromAssemblyContaining<AddProductInputModel>();
                Config.RegisterValidatorsFromAssemblyContaining<UpdateProductInputModel>();
                });

            return services;
       }
        
        public static IServiceCollection AddSwagger(this IServiceCollection services) 
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "devReviews.API", Version = "v1" });
            });

            return services;
        }  
    }
}