using Microsoft.Extensions.DependencyInjection;
using Service.Implement;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class ServiceCollections
    {
        public static IServiceCollection AddServiceCollections(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            return services;
        }
    }
}
