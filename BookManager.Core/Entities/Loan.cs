using BookManager.Core.Enums;

namespace BookManager.Core.Entities
{
    public class Loan : BaseEntity
    {
        public Loan(int idUsuario, int idLivro)
        {
            IdUsuario = idUsuario;
            IdLivro = idLivro;

            Status = LoanStatusEnun.Ativo;
            DataEmprestimo = DateTime.Now;
            DataPrevista = DataEmprestimo.AddDays(7);
        }

        public int IdUsuario { get; private set; }
        public int IdLivro { get; private set; }
        public LoanStatusEnun Status { get; private set; }
        public DateTime DataEmprestimo { get; private set; }
        public DateTime? DataPrevista { get; private set; }
        public DateTime? Devolvido { get; private set; }

        public User Cliente { get; private set; }
        public Book Book { get; private set; }
    }
}
