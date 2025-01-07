//using CarsAPI.DTOs;
using CarsAPI.DTOs;
using CarsAPI.Services.Interface;

namespace CarsAPI.Services
{
    public class CartService
    {
        private readonly Dictionary<int, List<CartItemResponseDTO>> _cartStorage = new Dictionary<int, List<CartItemResponseDTO>>();

        public async Task<CartReponseDTO?> GetCartAsync(int userId)
        {
            _cartStorage.TryGetValue(userId, out var cartItems);

            if (cartItems == null || !cartItems.Any())
                return null;

            return new CartReponseDTO
            {
                UserId = userId,
                Items = cartItems,
                TotalPrice = cartItems.Sum(item => item.Price * item.Quantity)
            };
        }

        public async Task AddToCartAsync(CartRequestDTO cartItem)
        {
            if (!_cartStorage.ContainsKey(cartItem.UserId))
            {
                _cartStorage[cartItem.UserId] = new List<CartItemResponseDTO>();
            }

            var userCart = _cartStorage[cartItem.UserId];
            var existingItem = userCart.FirstOrDefault(item => item.CarId == cartItem.CarId);

            if (existingItem != null)
            {
                // If the item exists, update the quantity
                existingItem.Quantity += cartItem.Quantity;
            }
            else
            {
                // Add new item to the cart
                userCart.Add(new CartItemResponseDTO
                {
                    CarId = cartItem.CarId,
                    Quantity = cartItem.Quantity
                });
            }
        }

        public async Task<bool> RemoveFromCartAsync(int userId, int carId)
        {
            if (!_cartStorage.ContainsKey(userId)) return false;

            var userCart = _cartStorage[userId];
            var itemToRemove = userCart.FirstOrDefault(item => item.CarId == carId);

            if (itemToRemove == null) return false;

            userCart.Remove(itemToRemove);
            return true;
        }

        public async Task<bool> ClearCartAsync(int userId)
        {
            if (!_cartStorage.ContainsKey(userId)) return false;

            _cartStorage[userId].Clear();
            return true;
        }
    }
}
