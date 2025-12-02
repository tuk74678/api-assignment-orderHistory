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
            try
            {
                var createdOrder = await _orderService.InsertOrderAsync(orderModel);
                return Ok(createdOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Orders>> DeleteOrder(int id)
        {
            var deletedOrder = await _orderService.DeleteOrderAsync(id);
            if (deletedOrder == null) return NotFound();
            return Ok(deletedOrder);
        }
    }
}
