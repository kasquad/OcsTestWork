using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OcsTestWork.Domain.Enumerations;
using OcsTestWork.Persistence.Primitives;

namespace OcsTestWork.Persistence.DbModels;

[Table("orders")]
public partial class OrderDb : EntityDb
{
    [Required]
    [Column("status")]
    public Int16 Status { get; set; } = OrderStatus.New.Id;
    public HashSet<OrderedProductDb> OrderedProducts { get; set; }
}