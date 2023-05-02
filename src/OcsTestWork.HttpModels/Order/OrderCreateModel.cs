using OcsTestWork.HttpModels.OrderedProduct;

namespace OcsTestWork.HttpModels.Order;

public class OrderCreateModel
{
    public Guid id { get; set; }
    /// <summary>
    /// ordered products
    /// </summary>
    public IEnumerable<OrderedProductModel> lines { get; set; }
}