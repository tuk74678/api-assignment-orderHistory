using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Contracts.Repositories;

public interface IOrderRepository: IRepository<Orders>
{
    Task<IEnumerable<Orders>> GetOrderByCustomerIdAsync(int customerId);
}