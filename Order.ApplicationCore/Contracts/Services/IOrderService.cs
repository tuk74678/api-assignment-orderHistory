using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Contracts.Services;

public interface IOrderService
{
    Task<Orders> InsertOrderAsync(Orders order);
    Task<Orders> UpdateOrderAsync(Orders order);
    Task<Orders> DeleteOrderAsync(int id);
    Task<IEnumerable<Orders>> GetAllOrdersAsync();
    Task<Orders> GetOrderByIdAsync(int id);
    Task<IEnumerable<Orders>> GetOrderByCustomerIdAsync(int customerId);
}