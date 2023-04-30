using OcsTestWork.Domain.Primitives;

namespace OcsTestWork.Domain.Entities;

public class OrderedProduct : Entity
{
    public OrderedProduct(Guid id) : base(id)
    {
    }
    public uint Quantity { get; set; }
}