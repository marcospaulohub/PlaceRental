using PlaceRentalApp.Application.Models;
using PlaceRentalApp.Core.Entities;

namespace PlaceRentalApp.Application.Services.Interfaces
{
    public interface IUserService
    {
        User? GetById(int id);
        int InsertUser(CreateUserInputModel model);
    }
}
