namespace BookManager.Application.ViewModels
{
    public class LoanViewModel
    {
        public LoanViewModel(int id, DateTime dataEmprestimo, DateTime? dataPrevista, string nomeCliente, string tituloLivro)
        {
            Id = id;
            DataEmprestimo = dataEmprestimo;
            DataPrevista = dataPrevista;
            NomeCliente = nomeCliente;
            TituloLivro = tituloLivro;
        }

        public int Id { get; private set; }
        public DateTime DataEmprestimo { get; private set; }
        public DateTime? DataPrevista { get; private set; }
        public string NomeCliente { get; private set; }
        public string TituloLivro { get; private set; }
    }
}
