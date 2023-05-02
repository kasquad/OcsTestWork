using OcsTestWork.Domain.AggregateRoots;
using OcsTestWork.Domain.Entities;
using OcsTestWork.Domain.Enumerations;
using OcsTestWork.Domain.Primitives;

namespace OcsTestWork.Persistence.DbModels;

public partial class OrderDb
{
    public static Order? MapToOrder(OrderDb? orderDb)
    {
        var orderStatus = Enumeration.GetAll<OrderStatus>()
            .FirstOrDefault(s => s.Id == orderDb.Status);

        if (orderStatus == default)
        {
            throw new
                Exception($"Cannot find reflection id of order status in {nameof(OrderStatus)}.");
        }

        return new Order(orderDb.Id,
            orderStatus,
            new HashSet<OrderedProduct>(orderDb.OrderedProducts
                .Select(d => new OrderedProduct(d.Id,d.Quantity)
                )
            )
        );
    }

    public static OrderDb MapFromOrder(Order order)
    {
        return new OrderDb
        {
            Id = order.Id,
            Status = order.Status.Id,
            OrderedProducts = new HashSet<OrderedProductDb>(order.OrderedProducts
                .Select(o => new OrderedProductDb()
                {
                    Id = o.Id,
                    Quantity = o.Quantity,
                    OrderId = order.Id
                })
            )
        };
    }
}