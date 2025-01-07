//using CarsAPI.Models;

//namespace CarsAPI.Repository
//{
//    public class CarRepository
//    {
//        private readonly ApplicationDbContext _context;

//        public CarRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<IEnumerable<Cars>> GetAllAsync()
//        {
//            return await _context.Cars.ToListAsync();
//        }

//        public async Task<Cars> GetByIdAsync(int id)
//        {
//            return await _context.Cars.FindAsync(id);
//        }

//        public async Task AddAsync(Cars car)
//        {
//            await _context.Cars.AddAsync(car);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateAsync(Cars car)
//        {
//            _context.Cars.Update(car);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteAsync(int id)
//        {
//            var car = await _context.Cars.FindAsync(id);
//            if (car != null)
//            {
//                _context.Cars.Remove(car);
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}

