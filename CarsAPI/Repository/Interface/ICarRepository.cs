using CarsAPI.Models;

namespace CarsAPI.Repository.Interface
{
    public interface ICarRepository
    {
         
        Task<IEnumerable<Cars>> GetAllAsync();
        Task<Cars> GetByIdAsync(int id);
        Task AddAsync(Cars car);
        Task UpdateAsync(Cars car);
        Task DeleteAsync(int id);
    
    }
}
