using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OcsTestWork.Domain.Repositories;
using OcsTestWork.Persistence.Repositories;

namespace OcsTestWork.Persistence.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(Environment.GetEnvironmentVariable("DefaultPostgresConnectionString"));
        });


        services.AddTransient<IOrderRepository, OrderRepository>();
        
        return services;
    }
}