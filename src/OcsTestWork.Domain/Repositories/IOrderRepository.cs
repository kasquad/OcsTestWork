using OcsTestWork.Domain.AggregateRoots;

namespace OcsTestWork.Domain.Repositories;

public interface IOrderRepository
{
    public Task<Order?> GetByIdOrDefault(Guid orderId, CancellationToken cancellationToken);
    public Task<bool> Create(Order order, CancellationToken cancellationToken);
    public Task<bool> Update(Order order, CancellationToken cancellationToken);
    public Task<bool> DeleteById(Guid orderId, CancellationToken cancellationToken);
}