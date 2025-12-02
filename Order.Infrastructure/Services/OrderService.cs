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

    public async Task<OrderResponseDto> UpdateOrderAsync(UpdateOrderModel model)
    {
        // Load existing order
        var existingOrder = await _orderRepository.GetByIdAsync(model.Id);
        if (existingOrder == null)
            throw new Exception("Order not found");

        // Update basic properties
        existingOrder.Order_Date = model.Order_Date;
        existingOrder.CustomerName = model.CustomerName;
        existingOrder.ShippingAddress = model.ShippingAddress;

        // Replace OrderDetails safely
        existingOrder.OrderDetails.Clear();

        foreach (var d in model.OrderDetails)
        {
            existingOrder.OrderDetails.Add(new OrderDetail
            {
                Product_Name = d.Product_Name,
                Quantity = d.Quantity,
                Price = d.Price,
                Discount = d.Discount
            });
        }
        // Save changes to DB
        var updatedOrder = await _orderRepository.UpdateAsync(existingOrder);

        // Return Response DTO
        return new OrderResponseDto
        {
            Id = updatedOrder.Id,
            Order_Date = updatedOrder.Order_Date,
            CustomerId = updatedOrder.CustomerId,
            CustomerName = updatedOrder.CustomerName,
            ShippingAddress = updatedOrder.ShippingAddress,
            BillAmount = updatedOrder.BillAmount,
            Order_Status = updatedOrder.Order_Status,
            OrderDetails = updatedOrder.OrderDetails.Select(d => new OrderDetailResponseDto
            {
                Product_Name = d.Product_Name,
                Quantity = d.Quantity,
                Price = d.Price,
                Discount = d.Discount
            }).ToList()
        };
    }
    
    public async Task<Orders> DeleteOrderAsync(int id)
    {
        return await _orderRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Orders>> GetAllOrdersAsync()
    {
        return await _orderRepository.GetAllAsync();
    }

    public Task<Orders> GetOrderByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<OrderResponseDto>> GetOrderByCustomerIdAsync(int customerId)
    {
        // Load orders with their details from DB
        var orders = await _orderRepository.GetOrderByCustomerIdAsync(customerId);

        // Map entities to response DTOs
        var orderDtos = orders.Select(o => new OrderResponseDto
        {
            Id = o.Id,
            Order_Date = o.Order_Date,
            CustomerId = o.CustomerId,
            CustomerName = o.CustomerName,
            ShippingAddress = o.ShippingAddress,
            BillAmount = o.BillAmount,
            Order_Status = o.Order_Status,
            OrderDetails = o.OrderDetails?.Select(d => new OrderDetailResponseDto
            {
                Product_Name = d.Product_Name,
                Quantity = d.Quantity,
                Price = d.Price,
                Discount = d.Discount
            }).ToList() ?? new List<OrderDetailResponseDto>()
        }).ToList();

        return orderDtos;
    }
}