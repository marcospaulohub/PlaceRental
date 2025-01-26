using PlaceRentalApp.Core.Entities;

namespace PlaceRentalApp.Application.Models
{
    public class UserViewModel
    {
        public UserViewModel(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }

        public static UserViewModel FromEntity(User entity)
            => new UserViewModel(
                entity.FullName, 
                entity.Email);
    }
}
