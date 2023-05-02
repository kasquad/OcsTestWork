using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace OcsTestWork.Persistence.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(Environment.GetEnvironmentVariable("DefaultPostgresConnectionString"));
        });

        return services;
    }
}