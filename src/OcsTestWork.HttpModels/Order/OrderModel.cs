using OcsTestWork.HttpModels.OrderedProduct;

namespace OcsTestWork.HttpModels.Order;

public class OrderModel
{
    public Guid id { get; set; }
    public string status { get; set; }

    /// <summary>
    /// ordered products
    /// </summary>
    public IEnumerable<OrderedProductModel> lines { get; set; }
}