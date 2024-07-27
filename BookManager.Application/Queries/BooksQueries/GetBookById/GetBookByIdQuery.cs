using BookManager.Application.Models;
using BookManager.Application.ViewModels;
using MediatR;

namespace BookManager.Application.Queries.BooksQueries.GetBookById
{
    public class GetBookByIdQuery : IRequest<ResultViewModel<BookViewModel>>
    {
        public GetBookByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
