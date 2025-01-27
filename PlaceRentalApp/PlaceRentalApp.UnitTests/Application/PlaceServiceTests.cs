using NSubstitute;
using NSubstitute.ReceivedExtensions;
using PlaceRentalApp.Application.Models;
using PlaceRentalApp.Application.Services;
using PlaceRentalApp.Core.Entities;
using PlaceRentalApp.Core.IRepositories;

namespace PlaceRentalApp.UnitTests.Application
{
    public class PlaceServiceTests
    {
        [Fact]
        public void Insert_PlaceIsOk_Success()
        {
            // Arrange 
            var createPlaceInputModel = new CreatePlaceInputModel
            {
                Title = "Charming Beach House",
                Description = "A Beautiful and relaxing beach house located Jus",
                DailyPrice = 150.00m,
                Address = new AddressInputModel
                {
                    Street = "123 Ocean View",
                    Number = "100",
                    ZipCode = "12345",
                    District = "Seafront",
                    City = "Seaside",
                    State = "CA",
                    Country = "USA"
                },
                AllowedNumberPerson = 4,
                AllowPets = true,
                CreatedBy = 1
            };

            var repository = Substitute.For<IPlaceRepository>();

            repository
                .AddPlace(Arg.Any<Place>())
                .Returns(1);

            var service = new PlaceService(repository);

            // Act
            var result = service.InsertPlace(createPlaceInputModel);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(1, result.Data);

            repository.ReceivedWithAnyArgs().AddPlace(default);

            repository.Received(1).AddPlace(Arg.Is<Place>(
                p => p.Title == createPlaceInputModel.Title &&
                p.DailyPrice == createPlaceInputModel.DailyPrice));
        }

        [Fact]
        public void Insert_UserIsOk_Success()
        {
            // Arrange
            var createUserInputModel = new CreateUserInputModel
            {
                FullName = "Fulano da Silva",
                Email = "fulano@email.com",
                BirtDate = DateTime.Today
            };

            var repository = Substitute.For<IUserRepository>();

            repository
                .AddUser(Arg.Any<User>())
                .Returns(1);

            var service = new UserService(repository);

            // Act
            var result = service.InsertUser(createUserInputModel);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(1, result.Data);

            repository.ReceivedWithAnyArgs().AddUser(default);

            repository.Received(1).AddUser(Arg.Is<User>(
                u => u.FullName == createUserInputModel.FullName &&
                u.Email == createUserInputModel.Email));
        }
    }
}
