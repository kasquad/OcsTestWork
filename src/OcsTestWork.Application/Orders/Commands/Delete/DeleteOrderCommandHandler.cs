using OcsTestWork.Application.Abstractions.Messaging;
using OcsTestWork.Application.Helpers;
using OcsTestWork.Domain.Repositories;

namespace OcsTestWork.Application.Orders.Commands.Delete;

public class DeleteOrderCommandHandler : IAppRequestHandler<DeleteOrderCommand>
{
    private IOrderRepository _orderRepo;

    public DeleteOrderCommandHandler(IOrderRepository orderRepo)
    {
        _orderRepo = orderRepo;
    }

    public async Task<Result> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
    {
        var isDeleted = await _orderRepo.DeleteById(command.orderId, cancellationToken);

        if (isDeleted)
        {
            return Result.Failure("Order with that id not exists");
        }
        return Result.Success();
    }
}