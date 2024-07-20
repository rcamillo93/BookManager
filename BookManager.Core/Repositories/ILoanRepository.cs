using BookManager.Core.Entities;

namespace BookManager.Core.Repositories
{
    public interface ILoanRepository
    {
        Task<List<Loan>> GetAllLoanAsync();
        Task<Loan?> GetLoanByIdAsync(int id);
        Task AddAsync(Loan loan);
        Task SaveChangesAsync();
    }
}
