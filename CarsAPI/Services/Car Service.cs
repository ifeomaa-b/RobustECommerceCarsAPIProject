using AutoMapper;
using CarsAPI.Repository.Interface;
using CarsAPI.Services.Interface;
using CarsAPI.Models;
using CarsAPI.DTOs;

namespace CarsAPI.Services
{
    public class CarService:ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarService(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        // Get all cars
        public async Task<IEnumerable<CarResponseDTO>> GetAllAsync()
        {
            var cars = await _carRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CarResponseDTO>>(cars);
        }
        // Get a car by ID
        public async Task<CarResponseDTO> GetByIdAsync(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            if (car == null) throw new Exception($"Car with ID {id} not found.");
            return _mapper.Map<CarResponseDTO>(car);
        }

        // Add a new car
        public async Task AddAsync(CarRequestDTO carDto)
        {
            var car = _mapper.Map<Cars>(carDto);
            car.CreatedAt = DateTime.UtcNow;
            car.UpdatedAt = DateTime.UtcNow;
            await _carRepository.AddAsync(car);
        }

        // Update an existing car
        public async Task UpdateAsync(int id, CarRequestDTO carDto)
        {
            var car = await _carRepository.GetByIdAsync(id);
            if (car == null) throw new Exception($"Car with ID {id} not found.");

            _mapper.Map(carDto, car); // Update the car with new values
            car.UpdatedAt = DateTime.UtcNow;
            await _carRepository.UpdateAsync(car);
        }

        // Delete a car
        public async Task DeleteAsync(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            if (car == null) throw new Exception($"Car with ID {id} not found.");

            await _carRepository.DeleteAsync(id);
        }

        // Search cars by make, model, or description
        public async Task<IEnumerable<CarResponseDTO>> SearchAsync(string query)
        {
            var cars = await _carRepository.GetAllAsync();
            var filteredCars = cars.Where(c =>
                c.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                c.Model.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                c.Description.Contains(query, StringComparison.OrdinalIgnoreCase));

            return _mapper.Map<IEnumerable<CarResponseDTO>>(filteredCars);
        }

        // Filter cars by price range
        public async Task<IEnumerable<CarResponseDTO>> FilterByPriceAsync(double minPrice, double maxPrice)
        {
            var cars = await _carRepository.GetAllAsync();
            var filteredCars = cars.Where(c => c.Price >= minPrice && c.Price <= maxPrice);
            return _mapper.Map<IEnumerable<CarResponseDTO>>(filteredCars);
        }

        // Filter cars by year range
        public async Task<IEnumerable<CarResponseDTO>> FilterByYearAsync(int minYear, int maxYear)
        {
            var cars = await _carRepository.GetAllAsync();
            var filteredCars = cars.Where(c => c.Year >= minYear && c.Year <= maxYear);
            return _mapper.Map<IEnumerable<CarResponseDTO>>(filteredCars);
        }
    }

   
}
