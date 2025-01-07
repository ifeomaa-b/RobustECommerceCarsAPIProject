using CarsAPI.DTOs;
using CarsAPI.Repository;

namespace CarsAPI.Services.Interface
{
    public interface ICarService
    {
        Task<IEnumerable<CarResponseDTO>> GetAllAsync();
        Task<CarResponseDTO> GetByIdAsync(int id);
        Task AddAsync(CarRequestDTO carDto);
        Task UpdateAsync(int id, CarRequestDTO carDto);
        Task DeleteAsync(int id);

    }
}
