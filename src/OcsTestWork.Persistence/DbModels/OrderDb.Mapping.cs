using OcsTestWork.Domain.AggregateRoots;
using OcsTestWork.Domain.Entities;
using OcsTestWork.Domain.Enumerations;
using OcsTestWork.Domain.Primitives;

namespace OcsTestWork.Persistence.DbModels;

public partial class OrderDb
{
    public static explicit operator Order(OrderDb orderDb)
    {
        var orderStatus = Enumeration.GetAll<OrderStatus>()
            .FirstOrDefault(s => s.Id == orderDb.Status);

        if (orderStatus == default)
        {
            throw new 
                Exception($"Cannot find reflection id of order status in {nameof(OrderStatus)}.");
        }
        
        return new Order(orderDb.Id)
        {
            Status = orderStatus,
            OrderedProducts = new HashSet<OrderedProduct>(orderDb.OrderedProducts
                .Select(d =>
                    new OrderedProduct(d.Id) { Quantity = d.Quantity }
                )
            )
        };
    }
}