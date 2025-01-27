using PlaceRentalApp.Core.Entities;
using PlaceRentalApp.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceRentalApp.UnitTests.Core
{
    public class PlaceTests
    {
        [Fact]
        public void Update_PlaceAndDataAreOk_Success()
        {
            // Arrange
            var place = new Place(
                "Title",
                "Teste Description",
                100m,
                new Address("Street", "Number", "ZipCode", "District", "City", "State", "Country"),
                4,
                true,
                123);

            var newTitle = "New Title";
            var newDescription = "New Description";
            var newDailyPrice = 140m;

            // Act
            var result = place.Update(newTitle, newDescription, newDailyPrice);

            // Assert
            Assert.True(result);
            Assert.Equal(newTitle, place.Title);
            Assert.Equal(newDescription, place.Description);
            Assert.Equal(newDailyPrice, place.DailyPrice);
        }

        [Fact]
        public void Update_PlaceIsBlocked_False()
        {
            // Arrange
            var place = new Place(
                "Title",
                "Teste Description",
                100m,
                new Address("Street", "Number", "ZipCode", "District", "City", "State", "Country"),
                4,
                true,
                123);

            var newTitle = "New Title";
            var newDescription = "New Description";
            var newDailyPrice = 140m;

            place.Block();

            // Act
            var result = place.Update(newTitle, newDescription, newDailyPrice);

            // Assert
            Assert.False(result);
            Assert.NotEqual(newTitle, place.Title);
            Assert.NotEqual(newDescription, place.Description);
            Assert.NotEqual(newDailyPrice, place.DailyPrice);
        }

        [Fact]
        public void IsBookAllowed_AmountOfPersonAndPetOk_Succes()
        {
            // Arrange
            var place = new Place(
                "Title",
                "Teste Description",
                100m,
                new Address("Street", "Number", "ZipCode", "District", "City", "State", "Country"),
                4,
                true,
                123);

            // Act
            var isBookAllowed = place.IsBookAllowed(true, 2);

            // Assert
            Assert.True(isBookAllowed);
        }

        [Fact]
        public void IsBookAllowed_HasPetButNotAllowed_False()
        {
            // Arrange
            var place = new Place(
               "Title",
               "Teste Description",
               100m,
               new Address("Street", "Number", "ZipCode", "District", "City", "State", "Country"),
               4,
               false,
               123);

            // Act
            var isBookAllowed = place.IsBookAllowed(true, 3);

            // Assert
            Assert.False(isBookAllowed);
        }

        [Fact]
        public void IsBookAllowed_OverMaximumAllowedPerson_False()
        {
            // Arrange
            var place = new Place(
              "Title",
              "Teste Description",
              100m,
              new Address("Street", "Number", "ZipCode", "District", "City", "State", "Country"),
              4,
              true,
              123);

            // Act
            var isBookAllowed = place.IsBookAllowed(true, 5);

            // Assert
            Assert.False(isBookAllowed);
        }
    }
}
