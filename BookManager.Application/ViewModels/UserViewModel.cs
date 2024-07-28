namespace BookManager.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(int id, string name, string email, DateTime? dateRestriction)
        {
            Id = id;
            Name = name;
            Email = email;
            DateRestriction = dateRestriction;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime? DateRestriction { get; private set; }
    }
}
