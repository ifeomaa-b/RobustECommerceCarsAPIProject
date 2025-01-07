namespace CarsAPI.DTOs
{
    public class CartReponseDTO
    {
        public int UserId { get; set; }
        public List<CartItemResponseDTO> Items { get; set; }
        public double TotalPrice { get; set; }
    }
}
