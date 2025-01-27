using Microsoft.EntityFrameworkCore;
using PlaceRentalApp.Core.Entities;
using PlaceRentalApp.Core.IRepositories;

namespace PlaceRentalApp.Infrastructure.Persistence.Repositories
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly PlaceRentalDbContext _context;

        public PlaceRepository(PlaceRentalDbContext context)
        {
            _context = context;
        }

        public List<Place>? GetAllAvailable(string search, DateTime startDate, DateTime endDate)
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

            return availablePlaces;
        }
        public Place? GetById(int id)
        {
            var place = _context.Places
                .Include(p => p.User)
                .Include(p => p.Amenities)
                .SingleOrDefault(p => p.Id == id);

            return place;
        }
        public int AddPlace(Place place)
        {
            _context.Places.Add(place);
            _context.SaveChanges();

            return place.Id;
        }
        public void UpdatePlace(Place place)
        {
            _context.Places.Update(place);
            _context.SaveChanges();
        }
        public void DeletePlace(Place place)
        {
            _context.Places.Update(place);
            _context.SaveChanges();
        }
        public void AddAmenity(Amenity amenity)
        {
            _context.Amenities.Add(amenity);
            _context.SaveChanges();
        }
        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }
        public void AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
    }
}
