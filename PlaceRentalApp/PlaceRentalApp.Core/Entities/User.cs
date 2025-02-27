namespace PlaceRentalApp.Core.Entities
{
    public class User : BaseEntity
    {
        protected User() { }
        public User(string fullName, string email, DateTime birtDate, string password, string role)
            : base()
        {
            FullName = fullName;
            Email = email;
            BirtDate = birtDate;
            Password = password;
            Role = role;

            Books = [];
            Places = [];
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirtDate { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }

        public List<Book> Books { get; private set; }
        public List<Place> Places { get; private set; }

    }
}
