using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.ApplicationCore.Contracts.Repositories;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;
using Order.ApplicationCore.Models;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrder([FromBody] InsertOrderModel orderModel)
        {
            var order = new Orders()
            {
                Order_Date = orderModel.Order_Date,
                CustomerId = orderModel.CustomerId,
                CustomerName = orderModel.CustomerName,
                ShippingAddress = orderModel.ShippingAddress,
                OrderDetails = orderModel.OrderDetails.Select(d => new OrderDetail()
                {
                    Product_Name = d.Product_Name,
                    Quantity = d.Quantity,
                    Price = d.Price,
                    Discount = d.Discount
                }).ToList()
            };
            try
            {
                var createdOrder = await _orderService.InsertOrderAsync(order);

                // Map to DTO
                var createdOrderDto = new OrderResponseDto
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

                return Ok(createdOrderDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
