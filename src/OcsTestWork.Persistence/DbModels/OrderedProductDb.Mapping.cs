using OcsTestWork.Domain.Entities;

namespace OcsTestWork.Persistence.DbModels;

public partial class OrderedProductDb
{
    public static explicit operator OrderedProduct(OrderedProductDb orderedProductDb)
    {
        return new OrderedProduct(orderedProductDb.Id)
        {
            Quantity = orderedProductDb.Quantity
        };
    }
}