namespace PlaceRentalApp.Core.Entities
{
    public class Comment : BaseEntity
    {
        protected Comment() { }
        public Comment(int idUser, string comments)
        {
            IdUser = idUser;
            Comments = comments;
        }

        public int IdUser { get; private set; }
        public string Comments { get; private set; }
    }
}
