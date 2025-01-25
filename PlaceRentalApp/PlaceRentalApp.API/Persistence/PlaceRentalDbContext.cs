using PlaceRentalApp.API.Entities;

namespace PlaceRentalApp.API.Persistence
{
    public class PlaceRentalDbContext
    {
        public PlaceRentalDbContext()
        {
            Places = [];
            Amenities = [];
            Comments = [];
            Books = [];
            Users = [];
        }

        public List<Place>  Places { get; set; }
        public List<Amenity> Amenities { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Book> Books { get; set; }
        public List<User> Users { get; set; }
    }
}
