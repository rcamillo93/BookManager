using BookManager.Core.Entities;

namespace BookManager.Core.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task<List<Book?>> FindBooksAsync(string? title, string? author);
        Task AddAsync(Book book);
        Task SaveChangesAsync();
    }
}
