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
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
			services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
			services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
