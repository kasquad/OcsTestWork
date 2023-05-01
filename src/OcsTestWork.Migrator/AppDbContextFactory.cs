using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OcsTestWork.Persistence;

namespace OcsTestWork.Migrator;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    // TODO: Extract to env vars
    const string _devConn =  "Host=localhost:5426;Database=order-api;Username=postgres;Password=orderApiPassword;";
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        
        optionsBuilder.UseNpgsql(_devConn,            
            x =>
                x.MigrationsAssembly("OcsTestWork.Migrator"));

        return new AppDbContext(optionsBuilder.Options);
    }
}