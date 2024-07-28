namespace BookManager.Application.ViewModels
{
    public class LoanViewModel
    {
        public LoanViewModel(int id, DateTime dataEmprestimo, DateTime? dataPrevista, string nomeCliente, 
            string tituloLivro, DateTime? returned)
        {
            Id = id;
            Loandate = dataEmprestimo;
            ExpectedDate = dataPrevista;
            ClientName = nomeCliente;
            BookTitle = tituloLivro;
            Returned = returned;
        }

        public int Id { get; private set; }
        public DateTime Loandate { get; private set; }
        public DateTime? ExpectedDate { get; private set; }
        public DateTime? Returned { get; private set; }
        public string ClientName { get; private set; }
        public string BookTitle { get; private set; }
    }
}
