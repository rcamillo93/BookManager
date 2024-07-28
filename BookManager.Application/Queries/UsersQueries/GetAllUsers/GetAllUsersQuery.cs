using BookManager.Application.Models;
using BookManager.Application.ViewModels;
using MediatR;

namespace BookManager.Application.Queries.UsersQueries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<ResultViewModel<List<UserViewModel>>>
    {
    }
}
