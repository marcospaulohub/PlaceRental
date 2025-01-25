namespace PlaceRentalApp.API.Entities
{
    public class Comment : BaseEntity
    {
        public Comment(int idUser, string comments)
        {
            IdUser = idUser;
            Comments = comments;
        }

        public int IdUser { get; private set; }
        public string Comments { get; private set; }
    }
}
