using PlaceRentalApp.Core.Entities;

namespace PlaceRentalApp.Core.IRepositories
{
    public interface IUserRepository
    {
        User? GetById(int id);
        int AddUser(User user);
    }
}
