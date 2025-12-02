using Order.ApplicationCore.Entities;
using Order.ApplicationCore.Models;

namespace Order.ApplicationCore.Contracts.Services;

public interface IOrderService
{
    Task<OrderResponseDto> InsertOrderAsync(InsertOrderModel model);
    Task<Orders> UpdateOrderAsync(Orders order);
    Task<Orders> DeleteOrderAsync(int id);
    Task<IEnumerable<Orders>> GetAllOrdersAsync();
    Task<Orders> GetOrderByIdAsync(int id);
    Task<IEnumerable<Orders>> GetOrderByCustomerIdAsync(int customerId);
}