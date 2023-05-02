using OcsTestWork.Domain.DomainExceptions;
using OcsTestWork.Domain.Entities;
using OcsTestWork.Domain.Enumerations;
using OcsTestWork.Domain.Primitives;

namespace OcsTestWork.Domain.AggregateRoots;

public class Order : AggregateRoot
{
    public Order(Guid id, OrderStatus status, HashSet<OrderedProduct> orderedProducts,DateTime dateTime) : base(id)
    {
        if (orderedProducts is null || orderedProducts.Count == 0)
        {
            throw new DomainException("You cant create order without ordered products.");
        }
        Status = status;
        OrderedProducts = orderedProducts;
    }
    public Order(Guid id, OrderStatus status, HashSet<OrderedProduct> orderedProducts) : base(id)
    {
        if (orderedProducts is null || orderedProducts.Count == 0)
        {
            throw new DomainException("You cant create order without ordered products.");
        }
        Status = status;
        OrderedProducts = orderedProducts;
    }

    public static Order CreateNew(Guid id, IEnumerable<OrderedProduct> orderedProducts)
    {
        if (orderedProducts.Count() != orderedProducts.DistinctBy(p => p.Id).Count())
        {
            throw new DomainException("U cant add two or more same products");
        }
        return new Order(id, OrderStatus.New, new HashSet<OrderedProduct>(orderedProducts),DateTime.UtcNow);
    }
    public void Update(IEnumerable<OrderedProduct> orderedProducts, string status)
    {
        if (orderedProducts.Count() != orderedProducts.DistinctBy(p => p.Id).Count())
        {
            throw new DomainException("U cant add two or more same products");
        }

        var orderStatus = Enumeration.GetAll<OrderStatus>().FirstOrDefault(s => s.Name == status);
        if (orderStatus == default)
        {
            throw new DomainException("Invalid order status");
        }

        OrderedProducts = new HashSet<OrderedProduct>(orderedProducts);
        Status = orderStatus;
    }
    
    public DateTime DateTime { get; private set; }
    public OrderStatus Status { get; private set; }
    public HashSet<OrderedProduct> OrderedProducts { get; private set; }
}