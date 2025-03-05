using PlaceRentalApp.Core.Entities;

namespace PlaceRentalApp.Core.IRepositories
{
    public interface IUserRepository
    {
        User? GetById(int id);
        User? GetByLoginAndHash(string email, string hash);
        int AddUser(User user);
    }
}
