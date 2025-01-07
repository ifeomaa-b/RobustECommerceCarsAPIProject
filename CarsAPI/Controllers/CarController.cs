using Microsoft.AspNetCore.Mvc;
using CarsAPI.Models;
using System.Collections.Generic;

namespace CarsAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CarsController : ControllerBase
    {
      public List<Cars> CarsList = new List<Cars>
    {
        new Cars
        {
            Id = 1,
            Name = "Benz",
            Model = "E-Class",
            Year = 2022,
            Description = "Salon Car",
            Price = 200000000,
            Features = "Automatic, Sunroof"
        },
        new Cars
        {
            Id = 2,
            Name = "Thundra",
            Model = "TRD",
            Year = 2023,
            Description = "Truck Car",
            Price = 800000000,
            Features = "4WD, Diesel"
        },
        new Cars
        {
            Id = 3,
            Name = "Porsche",
            Model = "911",
            Year = 2021,
            Description = "Luxury Car",
            Price = 300000000,
            Features = "Convertible, Turbo"
        },
        new Cars
        {
            Id = 4,
            Name = "Porsche",
            Model = "Cayenne",
            Year = 2022,
            Description = "Luxury SUV",
            Price = 700000000,
            Features = "Automatic, All-Wheel Drive"
        },
        new Cars
        {
            Id = 5,
            Name = "Lamborghini",
            Model = "Huracan",
            Year = 2021,
            Description = "Sports Car",
            Price = 500000000,
            Features = "V10, Aerodynamic"
        }
    };



        //GET: api/cars
        [HttpGet]
        public ActionResult<IEnumerable<Cars>> GetAll()
        {
            return Ok(CarsList);
        }
        //GET/api/car/id
        [HttpGet("{id}")]
        public ActionResult<Cars> GetById(int id)
        {
            var Findcar = CarsList.FirstOrDefault(x => x.Id == id);
            if (Findcar == null)
            {
                return NotFound();
            }
            return Ok(CarsList);
        }

        //
        [HttpPut]
        public IActionResult UpdateCars(Cars cars)
        {
            var FindCar = CarsList.FirstOrDefault(x => x.Id == cars.Id);
            if (FindCar == null)
            {

                return NotFound();
            };
            FindCar.Name = cars.Name;
            FindCar.Description = cars.Description;
            FindCar.Price = cars.Price;

            return NoContent();
        }

        [HttpPost]
        public IActionResult PostCars(Cars cars)
        {
            cars.Id = CarsList.Max(x => x.Id) + 1;
            CarsList.Add(cars);
            return CreatedAtAction(nameof(GetById), new { id = cars.Id }, cars);
        }

        [HttpDelete]
        public IActionResult DeleteCars()
        {
            var FindCar = CarsList.FirstOrDefault(x => x.Id == 0);
            if (FindCar == null)
            {
                return NotFound();
            }
            CarsList.Remove(FindCar);
            return NoContent();

        }
    }
}
