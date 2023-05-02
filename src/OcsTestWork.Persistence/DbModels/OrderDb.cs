using OcsTestWork.Domain.Enumerations;
using OcsTestWork.Persistence.Primitives;

namespace OcsTestWork.Persistence.DbModels;

public partial class OrderDb : EntityDb
{
    public int Status { get; set; } = OrderStatus.New.Id;
    public HashSet<OrderedProductDb> OrderedProducts { get; set; }
}