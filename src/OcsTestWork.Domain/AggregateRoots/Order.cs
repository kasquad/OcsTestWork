using OcsTestWork.Domain.Entities;
using OcsTestWork.Domain.Primitives;

namespace OcsTestWork.Domain.AggregateRoots;

public class Order : AggregateRoot
{
    public Order(Guid id) : base(id)
    {
    }
    
    public int Status { get; set; }
    public IEnumerable<OrderedProduct> OrderedProducts { get; set; }
}