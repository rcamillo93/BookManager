using BookManager.Core.Entities;
using BookManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Infrastructure.Persistence.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly BookDbContext _dbContext;

        public LoanRepository(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Loan loan)
        {
            await _dbContext.AddAsync(loan);
            await SaveChangesAsync();
        }

        public async Task<List<Loan>> GetAllLoanAsync()
        {
            return await _dbContext.Loans
                .Include(b => b.Book)
                .Include(c => c.Cliente)
                .ToListAsync();
        }

        public async Task<Loan?> GetLoanByIdAsync(int id)
        {
            return await _dbContext.Loans.SingleOrDefaultAsync(loan => loan.Id == id);  
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
