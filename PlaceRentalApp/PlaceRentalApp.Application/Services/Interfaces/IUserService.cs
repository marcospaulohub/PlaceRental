using PlaceRentalApp.Application.Models;

namespace PlaceRentalApp.Application.Services.Interfaces
{
    public interface IUserService
    {
        ResultViewModel<UserViewModel?> GetById(int id);
        ResultViewModel<int> InsertUser(CreateUserInputModel model);
    }
}
