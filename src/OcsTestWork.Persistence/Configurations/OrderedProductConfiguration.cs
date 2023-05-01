using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OcsTestWork.Domain.Entities;

namespace OcsTestWork.Persistence.Configurations;

public class OrderedProductConfiguration : IEntityTypeConfiguration<OrderedProduct>
{
    public void Configure(EntityTypeBuilder<OrderedProduct> builder)
    {
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Quantity).IsRequired();
    }
}