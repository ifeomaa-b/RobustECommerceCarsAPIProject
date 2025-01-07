namespace CarsAPI.DTOs
{
    public class UserRequestDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // For account creation or updates
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
