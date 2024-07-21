namespace BookManager.Core.Entities
{
    public class Book : BaseEntity
    {
        public Book(string titulo, string autor, string iSBN, int anoPublicacao)
        {
            Titulo = titulo;
            Autor = autor;
            ISBN = iSBN;
            AnoPublicacao = anoPublicacao;
            Disponivel = true;

            CreatedAt = DateTime.Now;
        }

        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public string ISBN { get; private set; }
        public int AnoPublicacao { get; private set; }
        public bool Disponivel { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public List<Loan> LoansBook { get; private set; }

        public void AtualizarStatus(bool status)
        {
            Disponivel = status;
        }
    }
}
