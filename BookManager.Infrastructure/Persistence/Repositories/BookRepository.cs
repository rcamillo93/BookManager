using BookManager.Core.Entities;
using BookManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Infrastructure.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _dbContext;

        public BookRepository(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Book book)
        {
           await _dbContext.AddAsync(book);
           await SaveChangesAsync();
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _dbContext.Books.SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
