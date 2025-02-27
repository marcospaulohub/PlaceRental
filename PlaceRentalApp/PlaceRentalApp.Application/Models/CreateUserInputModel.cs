namespace PlaceRentalApp.Application.Models
{
    public class CreateUserInputModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirtDate { get; set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
    }
}
