using Microsoft.EntityFrameworkCore;
using OcsTestWork.Domain.AggregateRoots;
using OcsTestWork.Domain.Entities;
using OcsTestWork.Persistence.DbModels;

namespace OcsTestWork.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<OrderDb> Orders { get; set; }
    public DbSet<OrderedProductDb> OrderedProducts { get; set; }
}