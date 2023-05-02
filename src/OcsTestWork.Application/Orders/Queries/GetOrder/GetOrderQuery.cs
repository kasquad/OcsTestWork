using OcsTestWork.Application.Abstractions.Messaging;
using OcsTestWork.Application.Models.Order;

namespace OcsTestWork.Application.Orders.Queries.GetOrder;

public record GetOrderQuery(Guid OrderId) : IAppRequest<OrderVm>;