using OcsTestWork.Domain.DomainExceptions;
using OcsTestWork.Domain.Entities;
using OcsTestWork.Domain.Enumerations;
using OcsTestWork.Domain.Primitives;

namespace OcsTestWork.Domain.AggregateRoots;

public class Order : AggregateRoot
{
    public Order(Guid id, OrderStatus status, HashSet<OrderedProduct> orderedProducts) : base(id)
    {
        if (orderedProducts is null || orderedProducts.Count == 0)
        {
            throw new DomainException("You cant create order without ordered products.");
        }
        Status = status;
        OrderedProducts = orderedProducts;
    }

    public OrderStatus Status { get; private set; }
    public HashSet<OrderedProduct> OrderedProducts { get; private set; }
}