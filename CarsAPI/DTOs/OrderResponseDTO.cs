namespace CarsAPI.DTOs
{
    public class OrderResponseDTO
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public List<OrderItemResponseDTO> Items { get; set; }
        public double TotalPrice { get; set; }
        public string PaymentMethod { get; set; }
        public string DeliveryAddress { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
