using BookManager.Core.Entities;

namespace BookManager.Core.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>>GetAllUsersAsync();
        Task<User?> GetUserByIdSAsync(int id);
        Task AddAsync(User user);
        Task SaveChangesAsync();

    }
}
