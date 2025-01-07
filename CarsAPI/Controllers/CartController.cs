using Microsoft.AspNetCore.Mvc;
using CarsAPI.Services.Interface;
using CarsAPI.Services;
using CarsAPI.Repository;
using CarsAPI.DTOs;

namespace CarsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        /// Get the cart for a specific user.
        
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCart(int userId)
        {
            var cart = await _cartService.GetCartAsync(userId);
            if (cart == null) return NotFound("Cart not found for the user.");
            return Ok(cart);
        }

        /// Add an item to the cart.
        [HttpPost("add")]
        public async Task<IActionResult> AddToCart([FromBody] CartRequestDTO cartItem)
        {
            if (cartItem == null) return BadRequest("Invalid cart item.");
            await _cartService.AddToCartAsync(cartItem);
            return Ok("Item added to cart.");
        }

        /// Remove a specific item from the cart.
        [HttpDelete("remove/{userId}/{carId}")]
        public async Task<IActionResult> RemoveFromCart(int userId, int carId)
        {
            var result = await _cartService.RemoveFromCartAsync(userId, carId);
            if (!result) return NotFound("Item not found in cart.");
            return Ok("Item removed from cart.");
        }

        /// Clear the entire cart for a user.
        [HttpDelete("{userId}")]
        public async Task<IActionResult> ClearCart(int userId)
        {
            var result = await _cartService.ClearCartAsync(userId);
            if (!result) return NotFound("Cart not found for the user.");
            return Ok("Cart cleared.");
        }
    }
}
