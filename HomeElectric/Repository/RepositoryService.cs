using Microsoft.Extensions.DependencyInjection;
using Repository.IRepository;
using Repository.Repositories;

namespace Repository
{
    public static class RepositoryService
    {
        public static IServiceCollection AddRepositoryService(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            
            return services;
        }
    }
}
