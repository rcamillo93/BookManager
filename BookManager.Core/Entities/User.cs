namespace BookManager.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string nome, string email)
        {
            Nome = nome;
            Email = email;

            CreatedAt = DateTime.Now;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public List<Loan> Loans { get; private set; }
    }
}
