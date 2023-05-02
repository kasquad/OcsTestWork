using Microsoft.EntityFrameworkCore;
using OcsTestWork.Persistence.DbModels;
using OcsTestWork.Persistence.EntityTypeConfigurations;

namespace OcsTestWork.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderedProductConfiguration());
    }

    public DbSet<OrderDb> Orders { get; set; }
    public DbSet<OrderedProductDb> OrderedProducts { get; set; }
    
    
}