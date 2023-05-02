using OcsTestWork.Application.Abstractions.Messaging;

namespace OcsTestWork.Application.Orders.Commands.Delete;

public record DeleteOrderCommand(Guid orderId) : IAppRequest;