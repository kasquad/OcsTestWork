using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OcsTestWork.Persistence.Primitives;

namespace OcsTestWork.Persistence.DbModels;

[Table("ordered_products")]
public partial class OrderedProductDb : EntityDb
{
    public OrderDb Order { get; set; }
    public Guid OrderId { get; set; }
    public uint Quantity { get; set; } = 1;
}