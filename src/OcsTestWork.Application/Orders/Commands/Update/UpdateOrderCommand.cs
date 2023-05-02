using OcsTestWork.Application.Abstractions.Messaging;
using OcsTestWork.Application.Models.Order;
using OcsTestWork.Domain.Entities;

namespace OcsTestWork.Application.Orders.Commands.Update;

public record UpdateOrderCommand(Guid OrderId,string status,IEnumerable<OrderedProduct> OrderedProducts) : IAppRequest<OrderVm>;