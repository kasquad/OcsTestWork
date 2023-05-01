using OcsTestWork.Domain.Entities;
using OcsTestWork.Domain.Enumerations;
using OcsTestWork.Domain.Primitives;

namespace OcsTestWork.Domain.AggregateRoots;

public class Order : AggregateRoot
{
    public Order(Guid id) : base(id)
    {
    }
    
    public OrderStatus Status { get; set; }
    public IEnumerable<OrderedProduct> OrderedProducts { get; set; }
}