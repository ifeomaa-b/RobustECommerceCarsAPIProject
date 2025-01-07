namespace CarsAPI.DTOs
{
    public class OrderItemResponseDTO
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double SubTotal { get; set; }
    }
}
