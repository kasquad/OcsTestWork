using OcsTestWork.Domain.AggregateRoots;

namespace OcsTestWork.Domain.Repositories;

public interface IOrderRepository
{
    public Task<Order?> GetByIdOrDefault(Guid orderId, CancellationToken cancellationToken);
    public Task Create(Order order, CancellationToken cancellationToken);
    public Task Update(Order orderUpdate, CancellationToken cancellationToken);
    public Task DeleteById(Guid orderId, CancellationToken cancellationToken);
}