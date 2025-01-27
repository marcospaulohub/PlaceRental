using PlaceRentalApp.Core.Entities;

namespace PlaceRentalApp.Core.IRepositories
{
    public interface IPlaceRepository
    {
        List<Place>? GetAllAvailable(string search, DateTime startDate, DateTime endDate);
        Place? GetById(int id);
        int AddPlace(Place place);
        void UpdatePlace(Place place);
        void DeletePlace(Place place);
        void AddBook(Book book);
        void AddAmenity(Amenity amenity);
        void AddComment(Comment comment);
    }
}
