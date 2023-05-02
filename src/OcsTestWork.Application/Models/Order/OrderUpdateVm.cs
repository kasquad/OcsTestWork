using OcsTestWork.HttpModels.OrderedProduct;

namespace OcsTestWork.Application.Models.Order;


public class OrderUpdateVm
{
    public Guid id { get; set; }
    public string status { get; set; }
    /// <summary>
    /// ordered products
    /// </summary>
    public IEnumerable<OrderedProductModel> lines { get; set; }
}