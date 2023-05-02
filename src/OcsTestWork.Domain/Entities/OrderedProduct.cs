using OcsTestWork.Domain.DomainExceptions;
using OcsTestWork.Domain.Primitives;

namespace OcsTestWork.Domain.Entities;

public class OrderedProduct : Entity
{
    public OrderedProduct(Guid id,uint quantity) : base(id)
    {
        if (quantity <= 0)
        {
            throw new DomainException("Quantity of ordered products must be grate than zero.");
        }
    }
    public uint Quantity { get; private set; }
}