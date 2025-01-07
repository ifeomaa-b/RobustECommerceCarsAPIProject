namespace CarsAPI.DTOs
{
    public class CartRequestDTO
    {
        public int UserId { get; set; }
        public int CarId { get; set; }
        public int Quantity { get; set; }
    }
}
