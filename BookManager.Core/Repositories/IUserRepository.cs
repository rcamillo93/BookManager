using BookManager.Core.Entities;

namespace BookManager.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdSAsync(int id);
        Task AddAsync(User user);
        Task SaveChangesAsync();

    }
}
