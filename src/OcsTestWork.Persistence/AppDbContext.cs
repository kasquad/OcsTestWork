using Microsoft.EntityFrameworkCore;
using OcsTestWork.Domain.AggregateRoots;
using OcsTestWork.Domain.Entities;

namespace OcsTestWork.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderedProduct> OrderedProducts { get; set; }
}