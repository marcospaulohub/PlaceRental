using Microsoft.EntityFrameworkCore;
using PlaceRentalApp.Application.Exceptions;
using PlaceRentalApp.Application.Models;
using PlaceRentalApp.Application.Services.Interfaces;
using PlaceRentalApp.Core.Entities;
using PlaceRentalApp.Core.ValueObjects;
using PlaceRentalApp.Infrastructure.Persistence;

namespace PlaceRentalApp.Application.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly PlaceRentalDbContext _context;

        public PlaceService(PlaceRentalDbContext context)
        {
            _context = context;
        }

        public List<PlaceViewModel> GetAllAvailable(string search, DateTime startDate, DateTime endDate)
        {
            var availablePlaces = _context
                 .Places
                 .Include(p => p.User)
                 .Where(p =>
                     p.Title.Contains(search) &&
                     !p.Books.Any(b =>
                     (startDate >= b.StartDate && startDate <= b.EndDate) ||
                     (endDate >= b.StartDate && endDate <= b.EndDate) ||
                     (startDate <= b.StartDate && endDate >= b.EndDate))
                     && !p.IsDeleted)
                 .ToList();

            var list = availablePlaces.Select(
                PlaceViewModel.FromEntity).ToList();

            return list;
        }

        public PlaceDetailsViewModel? GetById(int id)
        {
            var place = _context.Places.SingleOrDefault(p => p.Id == id);

            if (place is null)
                throw new NotFoundException();

            return PlaceDetailsViewModel.FromEntiry(place);
        }
        public int InsertPlace(CreatePlaceInputModel model)
        {
            var addres = new Address(
                model.Address.Street,
                model.Address.Number,
                model.Address.ZipCode,
                model.Address.District,
                model.Address.City,
                model.Address.State,
                model.Address.Country
                );

            var place = new Place(
                model.Title,
                model.Description,
                model.DailyPrice,
                addres,
                model.AllowedNumberPerson,
                model.AllowPets,
                model.CreatedBy
                );

            _context.Places.Add(place);
            _context.SaveChanges();

            return place.Id;
        }

        public void UpdatePlace(int id, UpdatePlaceInputModel model)
        {
            var place = _context.Places.SingleOrDefault(p => p.Id == id);

            if (place is null)
                throw new NotFoundException();

            place.Update(model.Title, model.Description, model.DailyPrice);

            _context.Places.Update(place);
            _context.SaveChanges();
        }
        public void DeletePlace(int id)
        {
            var place = _context.Places.SingleOrDefault(p => p.Id == id);

            if (place is null)
                throw new NotFoundException();

            place.SetAsDeleted();

            _context.Places.Update(place);
            _context.SaveChanges();
        }

        public void InsertAmenity(int id, CreateAmenityInputModel model)
        {
            var exists = _context.Places.Any(p => p.Id == id);

            if (!exists)
                throw new NotFoundException();

            var amenity = new Amenity(model.Description, id);

            _context.Amenities.Add(amenity);
            _context.SaveChanges();
        }

        public void InsertBook(int id, CreateBookInputModel model)
        {
            var exists = _context.Places.Any(p => p.Id == id);

            if (!exists)
                throw new NotFoundException();

            var book = new Book(model.IdUser, model.IdPlace, model.StartDate, model.EndDate, model.Comments);

            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void InsertComment(int id, CreateCommentInputModel model)
        {
            var place = _context.Places.SingleOrDefault(p => p.Id == id);

            if (place is null)
                throw new NotFoundException();

            var comment = new Comment(model.IdUser, model.Comments);

            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

    }
}
