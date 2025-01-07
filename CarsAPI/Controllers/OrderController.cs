//using CarsAPI.DTOs;
//using Microsoft.AspNetCore.Mvc;
//using CarsAPI.Services.Interface;
//namespace CarsAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class OrderController : ControllerBase
//    {
//        private readonly IOrderService _orderService;

//        public OrderController(IOrderService orderService)
//        {
//            _orderService = orderService;
//        }

//        /// Place a new order.
//        [HttpPost("place")]
//        public async Task<IActionResult> PlaceOrder([FromBody] OrderRequestDTO orderDto)
//        {
//            if (orderDto == null) return BadRequest("Invalid order request.");

//            var orderId = await _orderService.PlaceOrderAsync(orderDto);
//            return CreatedAtAction(nameof(GetOrderById), new { orderId }, new { orderId });
//        }

//        /// Get an order by its ID.
//        [HttpGet("{orderId}")]
//        public async Task<IActionResult> GetOrderById(int orderId)
//        {
//            var order = await _orderService.GetOrderByIdAsync(orderId);
//            return order != null ? Ok(order) : NotFound("Order not found.");
//        }

//        /// Get all orders for a specific user.
//        [HttpGet("user/{userId}")]
//        public async Task<IActionResult> GetOrdersByUser(int userId)
//        {
//            var orders = await _orderService.GetOrdersByUserAsync(userId);
//            return Ok(orders);
//        }

//        /// Update the status of an existing order.
//        [HttpPut("{orderId}")]
//        public async Task<IActionResult> UpdateOrderStatus(int orderId, [FromBody] OrderStatusUpdateDTO statusUpdate)
//        {
//            if (statusUpdate == null) return BadRequest("Invalid status update request.");

//            var success = await _orderService.UpdateOrderStatusAsync(orderId, statusUpdate);
//            return success ? NoContent() : NotFound("Order not found or update failed.");
//        }
//    }
//}
