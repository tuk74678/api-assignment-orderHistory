using Order.ApplicationCore.Entities;
using Order.ApplicationCore.Models;

namespace Order.ApplicationCore.Contracts.Services;

public interface IOrderService
{
    Task<OrderResponseDto> InsertOrderAsync(InsertOrderModel model);
    Task<OrderResponseDto> UpdateOrderAsync(UpdateOrderModel model);
    Task<Orders> DeleteOrderAsync(int id);
    Task<IEnumerable<Orders>> GetAllOrdersAsync();
    Task<Orders> GetOrderByIdAsync(int id);
    Task<IEnumerable<OrderResponseDto>> GetOrderByCustomerIdAsync(int customerId);
}