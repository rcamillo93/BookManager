using BookManager.Core.Enums;

namespace BookManager.Core.Entities
{
    public class Loan : BaseEntity
    {
        public Loan(int idUser, int idBook)
        {
            IdUser = idUser;
            IdBook = idBook;

            Status = LoanStatusEnun.Active;
            LoanDate = DateTime.Now;
            ExpectedDate = LoanDate.AddDays(7);
        }

        public int IdUser { get; private set; }
        public int IdBook { get; private set; }
        public LoanStatusEnun Status { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime? ExpectedDate { get; private set; }
        public DateTime? Returned { get; private set; }        

        public User Client { get; private set; }
        public Book Book { get; private set; }

        public void FinishLoan()
        {
            if(Status == LoanStatusEnun.Active || Status == LoanStatusEnun.Renovated)
            {
                Returned = DateTime.Now;
                Book.AtualizarStatus(true);
                Status = LoanStatusEnun.Finished;
            }
            else if(Status == LoanStatusEnun.Late)
            {
                Returned = DateTime.Now;
                Book.AtualizarStatus(true);
                Client.SetRestriction();
            }
        }

        public void RenewLoan()
        {
            if(Status == LoanStatusEnun.Active)
            {
                ExpectedDate = ExpectedDate?.AddDays(7);
                Status = LoanStatusEnun.Renovated;
            }
        }
    }
}
