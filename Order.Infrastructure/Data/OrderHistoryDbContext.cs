using Microsoft.EntityFrameworkCore;

namespace Order.Infrastructure.Data;

public class OrderHistoryDbContext: DbContext
{
    public OrderHistoryDbContext(DbContextOptions<OrderHistoryDbContext> options) : base(options)
    {
        
    }
}