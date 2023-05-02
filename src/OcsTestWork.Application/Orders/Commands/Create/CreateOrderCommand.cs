using OcsTestWork.Application.Abstractions.Messaging;
using OcsTestWork.Application.Models.Order;
using OcsTestWork.Domain.Entities;

namespace OcsTestWork.Application.Orders.Commands.Create;

public record CreateOrderCommand(Guid OrderId,IEnumerable<OrderedProduct> OrderedProducts) : IAppRequest<OrderVm>;