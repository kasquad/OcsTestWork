using OcsTestWork.Application.Abstractions.Messaging;
using OcsTestWork.Application.Helpers;
using OcsTestWork.Application.Models.Order;
using OcsTestWork.Domain.AggregateRoots;
using OcsTestWork.Domain.Entities;
using OcsTestWork.Domain.Repositories;

namespace OcsTestWork.Application.Orders.Commands.Create;

public class CreateOrderCommandHandler : IAppRequestHandler<CreateOrderCommand,OrderVm>
{
    private IOrderRepository _orderRepo;

    public CreateOrderCommandHandler(IOrderRepository orderRepo)
    {
        _orderRepo = orderRepo;
    }

    public async Task<Result<OrderVm>> Handle(
        CreateOrderCommand command,
        CancellationToken cancellationToken)
    {
        var order = Order
            .CreateNew(command.OrderId, command.OrderedProducts.Select(p => new OrderedProduct(p.Id, p.Quantity)));
        
        var isSuccess = await _orderRepo
            .Create(order, cancellationToken);

        if (!isSuccess)
        {
            return Result<OrderVm>.Failure("Order with same id is present");
        }

        var orderVm = OrderVm.ToOrderVm(order);

        return Result<OrderVm>.Success(orderVm);
    }
}