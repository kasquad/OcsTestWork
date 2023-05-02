using OcsTestWork.Application.Abstractions.Messaging;
using OcsTestWork.Application.Helpers;
using OcsTestWork.Application.Models.Order;
using OcsTestWork.Domain.AggregateRoots;
using OcsTestWork.Domain.Entities;
using OcsTestWork.Domain.Repositories;

namespace OcsTestWork.Application.Orders.Commands.Update;

public class UpdateOrderCommandHandler : IAppRequestHandler<UpdateOrderCommand,OrderVm>
{
    private IOrderRepository _orderRepo;

    public UpdateOrderCommandHandler(IOrderRepository orderRepo)
    {
        _orderRepo = orderRepo;
    }

    public async Task<Result<OrderVm>> Handle(
        UpdateOrderCommand command,
        CancellationToken cancellationToken)
    {
        var order = await _orderRepo.GetByIdOrDefault(command.OrderId, cancellationToken);

        if (order is null)
        {
            return Result<OrderVm>.Failure("Order with that id not exists.");
        } 
        order.Update(command.OrderedProducts,command.status);
        
        var isUpdated = await _orderRepo.Update(order, cancellationToken);

        if (!isUpdated)
        {
            return Result<OrderVm>.Failure("Somethind whent wrong.");
        }

        return Result<OrderVm>.Success(OrderVm.ToOrderVm(order));
    }
}