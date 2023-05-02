using System.Data;
using OcsTestWork.HttpModels.OrderedProduct;

namespace OcsTestWork.Application.Models.Order;

public class OrderVm
{
    public Guid id { get; set; }
    public string status { get; set; }

    /// <summary>
    /// ordered products
    /// </summary>
    public IEnumerable<OrderedProductModel> lines { get; set; }

    public static OrderVm ToOrderVm(Domain.AggregateRoots.Order order)
    {
        return new OrderVm()
        {
            id = order.Id,
            status = order.Status.Name,
            lines = order.OrderedProducts.Select(p => new OrderedProductModel()
            {
                id = p.Id,
                qty = p.Quantity
            })
        };
    } 
}