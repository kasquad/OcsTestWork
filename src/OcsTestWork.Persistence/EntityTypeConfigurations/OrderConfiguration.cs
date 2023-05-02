using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OcsTestWork.Persistence.DbModels;

namespace OcsTestWork.Persistence.EntityTypeConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<OrderDb>
{
    public void Configure(EntityTypeBuilder<OrderDb> builder)
    {
        builder
            .ToTable("orders");
        
        builder
            .HasKey(e => e.Id);
        
        builder
            .Property(e => e.Id)
            .HasColumnName("id");
        
        builder
            .HasIndex(e => e.Id);

        builder
            .Property(e => e.Status)
            .IsRequired()
            .HasColumnName("status");
        
        builder
            .HasMany(e => e.OrderedProducts)
            .WithOne(e => e.Order)
            .HasForeignKey(e => e.OrderId);
    }
}