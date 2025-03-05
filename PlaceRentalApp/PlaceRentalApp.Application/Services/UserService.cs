using PlaceRentalApp.Application.Models;
using PlaceRentalApp.Application.Services.Interfaces;
using PlaceRentalApp.Core.Entities;
using PlaceRentalApp.Core.IRepositories;
using PlaceRentalApp.Infrastructure.Auth;

namespace PlaceRentalApp.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public UserService(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
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
            var hash = _authService.ComputeHash(model.Password);
            var user = new User(model.FullName, model.Email, model.BirtDate, hash, model.Role);
            var userId = _userRepository.AddUser(user);

            return ResultViewModel<int>.Success(userId);
        }

        public ResultViewModel<LoginViewModel?> Login(LoginInputModel model)
        {
            var hash = _authService.ComputeHash(model.Password);
            var user = _userRepository.GetByLoginAndHash(model.Email, hash);

            if (user is null)
                return ResultViewModel<LoginViewModel?>.Error("Error");

            var token = _authService.GenerateToken(user.Email, user.Role);
            var viewModel = LoginViewModel.FromEntity(token);

            return ResultViewModel<LoginViewModel?>.Success(viewModel);
        }
    }
}
