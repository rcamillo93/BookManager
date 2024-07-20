using BookManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Infrastructure.Persistence
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) :base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
