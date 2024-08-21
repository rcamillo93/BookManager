namespace BookManager.Core.Services
{
    public interface ISendEmailService
    {
        Task CreateLoanEmail(int idLoan);
        Task RenewLoanEmail(int idLoan);
        Task FinishLoanEmail(int idLoan);
    }
}
