using PlaceRentalApp.Application.Models;
using PlaceRentalApp.Application.Services.Interfaces;
using PlaceRentalApp.Core.Entities;
using PlaceRentalApp.Core.IRepositories;

namespace PlaceRentalApp.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ResultViewModel<UserViewModel?> GetById(int id)
        {
            var user = _userRepository.GetById(id);

            if (user is null)
                return ResultViewModel<UserViewModel?>.Error("Not Found");
            
            return ResultViewModel<UserViewModel?>.Success(UserViewModel.FromEntity(user));
        }

        public ResultViewModel<int> InsertUser(CreateUserInputModel model)
        {
            var user = new User(model.FullName, model.Email, model.BirtDate);

            _userRepository.AddUser(user);

            return ResultViewModel<int>.Success(user.Id);
        }
    }
}
