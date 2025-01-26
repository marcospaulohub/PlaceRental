using PlaceRentalApp.Application.Models;

namespace PlaceRentalApp.Application.Services.Interfaces
{
    public interface IPlaceService
    {
        ResultViewModel<List<PlaceViewModel>> GetAllAvailable(string search, DateTime startDate, DateTime endDate);
        ResultViewModel<PlaceDetailsViewModel?> GetById(int id);
        ResultViewModel<int> InsertPlace(CreatePlaceInputModel model);
        ResultViewModel UpdatePlace(int id, UpdatePlaceInputModel model);
        ResultViewModel DeletePlace(int id);

        ResultViewModel InsertAmenity(int id, CreateAmenityInputModel model);
        ResultViewModel InsertBook(int id, CreateBookInputModel model);
        ResultViewModel InsertComment(int id, CreateCommentInputModel model);
    }

}
