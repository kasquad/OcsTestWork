using Microsoft.EntityFrameworkCore;
using OcsTestWork.Domain.AggregateRoots;
using OcsTestWork.Domain.Repositories;
using OcsTestWork.Persistence.DbModels;

namespace OcsTestWork.Persistence.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Returns order by id with eager loaded orderedProducts.
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Order</returns>
    public async Task<Order?> GetByIdOrDefault(
        Guid orderId,
        CancellationToken cancellationToken)
    {
        var order = await _context
            .Orders
            .Include(o => o.OrderedProducts)
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Id == orderId,
                cancellationToken: cancellationToken);

        return OrderDb.MapToOrder(order);
    }

    public async Task<bool> Create(
        Order order,
        CancellationToken cancellationToken)
    {
        var orderDb = OrderDb.MapFromOrder(order);

        await _context.Orders
            .AddAsync(orderDb, cancellationToken);
        var addResult = await _context.SaveChangesAsync(cancellationToken);

        ;return addResult == 1;
    }

    public async Task<bool> Update(
        Order order,
        CancellationToken cancellationToken)
    {
        var orderDb = OrderDb.MapFromOrder(order);

        _context.Orders.Update(orderDb);

        var editResult = await _context.SaveChangesAsync(cancellationToken);
        
        return editResult == 1;
    }

    /// <summary>
    /// Delete order by id.
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>True if delete is success</returns>
    public async Task<bool> DeleteById(
        Guid orderId,
        CancellationToken cancellationToken)
    {
        var deleteResult = await _context
            .Orders
            .Where(o => o.Id == orderId)
            .ExecuteDeleteAsync(cancellationToken: cancellationToken);

        return deleteResult == 1;
    }
}