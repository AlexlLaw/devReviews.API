using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using devReviews.API.Services;
using devReviews.API.Persistence.Repositorys;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.AspNetCore;
using devReviews.API.Models;

namespace devReviews.API.Extensions
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddRepositorys(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();

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
    }
}