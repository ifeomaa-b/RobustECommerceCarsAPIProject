namespace CarsAPI.DTOs
{
    public class CarResponseDTO
    {
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Features { get; set; }
        public string ImageUrl { get; set; }
    }
}
