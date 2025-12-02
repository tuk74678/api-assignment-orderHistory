using Order.ApplicationCore.Contracts.Repositories;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;

namespace Order.Infrastructure.Services;

public class OrderService: IOrderService
{
    private readonly IOrderRepository _orderRepository;
    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    public Task<Orders> InsertOrderAsync(Orders order)
    {
        throw new NotImplementedException();
    }

    public Task<Orders> UpdateOrderAsync(Orders order)
    {
        throw new NotImplementedException();
    }

    public Task<Orders> DeleteOrderAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Orders>> GetAllOrdersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Orders> GetOrderByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Orders>> GetOrderByCustomerIdAsync(int customerId)
    {
        throw new NotImplementedException();
    }
}