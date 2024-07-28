using BookManager.Application.Models;
using BookManager.Application.ViewModels;
using MediatR;

namespace BookManager.Application.Queries.UsersQueries.GetUserById
{
    public class GetUserByIdQuery : IRequest<ResultViewModel<UserViewModel>>
    {
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
