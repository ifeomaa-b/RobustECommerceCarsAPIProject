using CarsAPI.DTOs;

namespace CarsAPI.Services.Interface
{
    public interface ICartService
    {
        // Task GetCartAsync(int userId);
        Task<CartReponseDTO> GetCartAsync(int userId);
        Task AddToCartAsync(CartRequestDTO cartItem);
        Task<bool> RemoveFromCartAsync(int userId, int carId);
        Task<bool> ClearCartAsync(int userId);

    }
}
