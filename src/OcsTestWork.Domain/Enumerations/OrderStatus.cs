using OcsTestWork.Domain.Primitives;

namespace OcsTestWork.Domain.Enumerations;

public class OrderStatus : Enumeration
{
    public OrderStatus(Int16 id, string name) : base(id, name)
    {
    }

    public static OrderStatus New = new(1, nameof(New));
    public static OrderStatus Paid = new(2, nameof(Paid));
    public static OrderStatus ForwardedForDelivery = new(3, nameof(ForwardedForDelivery));
    public static OrderStatus Delivered = new(4, nameof(Delivered));
    public static OrderStatus Completed = new(5, nameof(Completed));
}