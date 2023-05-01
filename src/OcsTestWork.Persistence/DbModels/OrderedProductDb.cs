using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OcsTestWork.Persistence.Primitives;

namespace OcsTestWork.Persistence.DbModels;

[Table("ordered_products")]
public partial class OrderedProductDb : EntityDb
{
    [ForeignKey(nameof(OrderId))]
    public OrderDb Order { get; set; }
    [Column("order_id")]
    public Guid OrderId { get; set; }
    
    [Required]
    [Column("quantity")]
    public uint Quantity { get; set; } = 1;
}