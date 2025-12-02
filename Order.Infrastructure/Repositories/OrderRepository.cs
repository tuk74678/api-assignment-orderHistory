using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Contracts.Repositories;
using Order.ApplicationCore.Entities;
using Order.Infrastructure.Data;

namespace Order.Infrastructure.Repositories;

public class OrderRepository: BaseRepository<Orders>, IOrderRepository
{
    public OrderRepository(OrderHistoryDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Orders>> GetOrderByCustomerIdAsync(int customerId)
    {
        var orders = await _orderHistoryDbContext.Set<Orders>()
            .AsNoTracking()
            .Include(o => o.OrderDetails)
            .Where(o => o.CustomerId == customerId)
            .ToListAsync();
        return orders;
    }
}