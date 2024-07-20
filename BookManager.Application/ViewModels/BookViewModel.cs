namespace BookManager.Application.ViewModels
{
    public class BookViewModel
    {
        public BookViewModel(int id, string titulo, string autor, string iSBN, int anoPublicacao, bool disponivel)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            ISBN = iSBN;
            AnoPublicacao = anoPublicacao;
            Disponivel = disponivel;
        }

        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public string ISBN { get; private set; }
        public int AnoPublicacao { get; private set; }
        public bool Disponivel { get; private set; }
    }
}
