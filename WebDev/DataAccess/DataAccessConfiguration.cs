using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class DataAccessConfiguration
{
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("WebDevDb");

        services.AddDbContext<WebDevDBcontext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IUserRepository, UserRepository>();  

        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddScoped<ICouponRepository, CouponRepository>();

        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }
}
