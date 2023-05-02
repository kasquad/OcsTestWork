using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OcsTestWork.Persistence.DbModels;

namespace OcsTestWork.Persistence.EntityTypeConfigurations;

public class OrderedProductConfiguration : IEntityTypeConfiguration<OrderedProductDb>
{
    public void Configure(EntityTypeBuilder<OrderedProductDb> builder)
    {
        builder
            .ToTable("ordered_products");
        
        builder
            .Property(e => e.Id)
            .HasColumnName("id");

        builder
            .Property(e => e.OrderId)
            .HasColumnName("order_id");

        builder
            .Property(e => e.Quantity)
            .HasColumnName("quantity");
        
        builder
            .HasKey(e => new { e.Id, e.OrderId });
        
        builder
            .HasOne(e => e.Order)
            .WithMany(e => e.OrderedProducts)
            .HasForeignKey(e => e.OrderId);
    }
}