using Bogus;
using PlaceRentalApp.Core.Entities;
using PlaceRentalApp.Core.ValueObjects;

namespace PlaceRentalApp.Test.Fakes
{
    public class AddressFake : Faker<Address>
    {
        public AddressFake()
        {
            CustomInstantiator(faker =>
            new Address(
                faker.Address.StreetName(),
                faker.Address.BuildingNumber(),
                faker.Address.ZipCode(),
                faker.Address.County(),
                faker.Address.City(),
                faker.Address.State(),
                faker.Address.Country()
                )
            );
        }
    }

    public class UserFake: Faker<User>
    {
        public UserFake()
        {
            CustomInstantiator(faker =>
            new User(
                faker.Name.FullName(),
                faker.Internet.Email(),
                faker.Date.Recent(365),
                faker.Internet.Password(),
                "admin")
            );
        }
    }

    public class AmenityFake: Faker<Amenity>
    {
        public AmenityFake()
        {
            CustomInstantiator(faker =>
            new Amenity(
                faker.Random.Word(),
                faker.Random.Number(1, 999)
            ));
        }
    }

    public class PlaceFake: Faker<Place> 
    {
        public PlaceFake()
        {
            CustomInstantiator(faker =>
            new Place(
                faker.Random.Word(),
                faker.Random.Word(),
                faker.Random.Number(1, 200),
                new AddressFake().Generate(),
                faker.Random.Number(1, 5),
                true,
                faker.Random.Number(1, 99)
            ));

            RuleFor(p => p.User, f => new UserFake().Generate());
            RuleFor(p => p.Amenities, f => new AmenityFake().Generate(5));
        }
    }
}
