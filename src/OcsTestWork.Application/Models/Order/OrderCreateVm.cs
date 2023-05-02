using OcsTestWork.HttpModels.OrderedProduct;

namespace OcsTestWork.Application.Models.Order;

public class OrderCreateVm
{
    public Guid id { get; set; }
    /// <summary>
    /// ordered products
    /// </summary>
    public IEnumerable<OrderedProductModel> lines { get; set; }
}