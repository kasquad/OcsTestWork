using OcsTestWork.Application.Abstractions.Messaging;
using OcsTestWork.Application.Helpers;
using OcsTestWork.Application.Models.Order;
using OcsTestWork.Domain.Repositories;

namespace OcsTestWork.Application.Orders.Queries.GetOrder;

public class GetOrderQueryHandler : IAppRequestHandler<GetOrderQuery, OrderVm>
{
    private IOrderRepository _orderRepo;

    public GetOrderQueryHandler(IOrderRepository orderRepo)
    {
        _orderRepo = orderRepo;
    }

    public async Task<Result<OrderVm>> Handle(
        GetOrderQuery request,
        CancellationToken cancellationToken)
    {
        var order = await _orderRepo
            .GetByIdOrDefault(request.OrderId, cancellationToken);

        if (order is null)
        {
            return Result<OrderVm>.Failure("Order is not found");
        }

        return Result<OrderVm>.Success(OrderVm.ToOrderVm(order));
    }
}