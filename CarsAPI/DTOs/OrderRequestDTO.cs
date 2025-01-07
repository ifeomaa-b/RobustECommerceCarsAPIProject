namespace CarsAPI.DTOs
{
    public class OrderRequestDTO
    {
        public int UserId { get; set; }
        public List<OrderItemRequestDTO> Items { get; set; }
        public string PaymentMethod { get; set; }
        public string DeliveryAddress { get; set; }
    }
}
