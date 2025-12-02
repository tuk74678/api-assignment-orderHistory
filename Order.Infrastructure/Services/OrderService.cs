using Order.ApplicationCore.Contracts.Repositories;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;
using Order.ApplicationCore.Models;

namespace Order.Infrastructure.Services;

public class OrderService: IOrderService
{
    private readonly IOrderRepository _orderRepository;
    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    public async Task<OrderResponseDto> InsertOrderAsync(InsertOrderModel model)
    {
        // Map DTO → Entity
        var order = new Orders
        {
            Order_Date = model.Order_Date,
            CustomerId = model.CustomerId,
            CustomerName = model.CustomerName,
            ShippingAddress = model.ShippingAddress,
            OrderDetails = model.OrderDetails.Select(d => new OrderDetail
            {
                Product_Name = d.Product_Name,
                Quantity = d.Quantity,
                Price = d.Price,
                Discount = d.Discount
            }).ToList()
        };

        // Save to DB
        var createdOrder = await _orderRepository.InsertAsync(order);

        // Map Entity → Response DTO to avoid Circular Reference
        return new OrderResponseDto
        {
            Id = createdOrder.Id,
            Order_Date = createdOrder.Order_Date,
            CustomerId = createdOrder.CustomerId,
            CustomerName = createdOrder.CustomerName,
            ShippingAddress = createdOrder.ShippingAddress,
            BillAmount = createdOrder.BillAmount,
            Order_Status = createdOrder.Order_Status,
            OrderDetails = createdOrder.OrderDetails.Select(d => new OrderDetailResponseDto
            {
                Product_Name = d.Product_Name,
                Quantity = d.Quantity,
                Price = d.Price,
                Discount = d.Discount
            }).ToList()
        };
    }

    public Task<Orders> UpdateOrderAsync(Orders order)
    {
        throw new NotImplementedException();
    }

    public async Task<Orders> DeleteOrderAsync(int id)
    {
        return await _orderRepository.DeleteAsync(id);
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