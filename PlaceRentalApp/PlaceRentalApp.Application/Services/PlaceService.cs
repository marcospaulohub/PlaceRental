using PlaceRentalApp.Application.Models;
using PlaceRentalApp.Application.Services.Interfaces;
using PlaceRentalApp.Core.Entities;
using PlaceRentalApp.Core.IRepositories;
using PlaceRentalApp.Core.ValueObjects;

namespace PlaceRentalApp.Application.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository _placeRepository;

        public PlaceService(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        public ResultViewModel<List<PlaceViewModel>> GetAllAvailable(string search, DateTime startDate, DateTime endDate)
        {
            var availablePlaces = 
                _placeRepository.GetAllAvailable(search, startDate, endDate) ?? []; 

            var list = availablePlaces.Select(
                PlaceViewModel.FromEntity).ToList();

            return ResultViewModel<List<PlaceViewModel>>.Success(list);
        }
        public ResultViewModel<PlaceDetailsViewModel?> GetById(int id)
        {
            var place = _placeRepository.GetById(id);

            if (place is null)
                return ResultViewModel<PlaceDetailsViewModel?>.Error("Not Found");

            return ResultViewModel<PlaceDetailsViewModel?>.Success(PlaceDetailsViewModel.FromEntiry(place));
        }
        public ResultViewModel<int> InsertPlace(CreatePlaceInputModel model)
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

            _placeRepository.AddPlace(place);

            return ResultViewModel<int>.Success(place.Id);
        }
        public ResultViewModel UpdatePlace(int id, UpdatePlaceInputModel model)
        {
            var place = _placeRepository.GetById(id);

            if (place is null)
                return ResultViewModel.Error("Not Found");

            place.Update(model.Title, model.Description, model.DailyPrice);

            _placeRepository.UpdatePlace(place);

            return ResultViewModel.Success();
        }
        public ResultViewModel DeletePlace(int id)
        {
            var place = _placeRepository.GetById(id);

            if (place is null)
                return ResultViewModel.Error("Not Found");

            place.SetAsDeleted();

            _placeRepository.DeletePlace(place);

            return ResultViewModel.Success();
        }
        public ResultViewModel InsertAmenity(int id, CreateAmenityInputModel model)
        {
            var place = _placeRepository.GetById(id);

            if (place is null)
                return ResultViewModel.Error("Not Found");

            var amenity = new Amenity(model.Description, id);

            _placeRepository.AddAmenity(amenity);

            return ResultViewModel.Success();
        }
        public ResultViewModel InsertBook(int id, CreateBookInputModel model)
        {
            var place = _placeRepository.GetById(id);

            if (place is null)
                return ResultViewModel.Error("Not Found");

             var book = new Book(model.IdUser, model.IdPlace, model.StartDate, model.EndDate, model.Comments);

            _placeRepository.AddBook(book);

            return ResultViewModel.Success(); 
        }
        public ResultViewModel InsertComment(int id, CreateCommentInputModel model)
        {
            var place = _placeRepository.GetById(id);

            if (place is null)
                return ResultViewModel.Error("Not Found");

            var comment = new Comment(model.IdUser, model.Comments);

            _placeRepository.AddComment(comment);

            return ResultViewModel.Success();
        }

    }
}
