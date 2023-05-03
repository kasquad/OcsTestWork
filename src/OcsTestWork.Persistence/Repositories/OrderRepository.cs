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

    public async Task Create(
        Order order,
        CancellationToken cancellationToken)
    {
        var orderCreate = OrderDb.MapFromOrder(order);

        await _context.Orders
            .AddAsync(orderCreate, cancellationToken);
        var addResult = await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(
        Order orderUpdate,
        CancellationToken cancellationToken)
    {
        var order = OrderDb.MapFromOrder(orderUpdate);

        var existingOrder = await _context.Orders
            .Include(o => o.OrderedProducts)
            .FirstOrDefaultAsync(o => o.Id == order.Id, cancellationToken);

        if (existingOrder == null)
        {
            throw new Exception("Order is not found.");
        }
        
        existingOrder.Status = order.Status;
        
        foreach (var orderedProduct in order.OrderedProducts)
        {
            var existingChildEntity = existingOrder.OrderedProducts
                .FirstOrDefault(c => c.Id == orderedProduct.Id);

            if (existingChildEntity != null)
            {
                existingChildEntity.Quantity = orderedProduct.Quantity;
            }
            else
            {
                existingOrder.OrderedProducts.Add(orderedProduct);
            }
        }

        foreach (var orderedProduct in existingOrder.OrderedProducts.ToList())
        {
            if (order.OrderedProducts.All(c => c.Id != orderedProduct.Id))
            {
                existingOrder.OrderedProducts.Remove(orderedProduct);
            }
        }

        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Delete order by id.
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>True if delete is success</returns>
    public async Task DeleteById(
        Guid orderId,
        CancellationToken cancellationToken)
    {
        var deleteResult = await _context
            .Orders
            .Where(o => o.Id == orderId)
            .ExecuteDeleteAsync(cancellationToken: cancellationToken);
    }
}