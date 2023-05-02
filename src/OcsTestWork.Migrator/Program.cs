using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using OcsTestWork.Persistence;

namespace OcsTestWork.Migrator;

public static class Program
{
    public static async Task Main()
    {
        // var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        //
        // optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("DefaultPostgresConnectionString"),            
        //     x =>
        //         x.MigrationsAssembly("OcsTestWork.Migrator"));
        //
        // var context=  new AppDbContext(optionsBuilder.Options);
        // var migrator = context.Database.GetService<IMigrator>();
        // await migrator.MigrateAsync();
    }
}