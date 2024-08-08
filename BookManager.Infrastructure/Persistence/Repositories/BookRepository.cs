using BookManager.Core.Entities;
using BookManager.Core.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Immutable;

namespace BookManager.Infrastructure.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _dbContext;
        private readonly string _connectionString;

        public BookRepository(BookDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("LibraryCs");
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

        public async Task<List<Book?>> FindBooksAsync(string? title, string? author)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT id, title, author, isbn, yearpublication, available FROM books WHERE 1=1 ";

                if(!string.IsNullOrEmpty(title))
                    sql += " and title LIKE @TITLE";

                if(!string.IsNullOrEmpty(author))
                    sql += " AND author LIKE @Author";


                var books = await sqlConnection.QueryAsync<Book>(sql, new { Title = "%" + title + "%", Author = "%" + author + "%" });

                return books.ToList();
            }
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
