using PlaceRentalApp.Application.Models;
using PlaceRentalApp.Core.Entities;

namespace PlaceRentalApp.Application.Services.Interfaces
{
    public interface IPlaceService
    {
        List<PlaceViewModel> GetAllAvailable(string search, DateTime startDate, DateTime endDate);
        PlaceDetailsViewModel? GetById(int id);
        int InsertPlace(CreatePlaceInputModel model);
        void UpdatePlace(int id, UpdatePlaceInputModel model);
        void DeletePlace(int id);

        void InsertAmenity(int id, CreateAmenityInputModel model);
        void InsertBook(int id, CreateBookInputModel model);
        void InsertComment(int id, CreateCommentInputModel model);
    }

}
