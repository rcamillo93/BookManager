namespace BookManager.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(int id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
    }
}
