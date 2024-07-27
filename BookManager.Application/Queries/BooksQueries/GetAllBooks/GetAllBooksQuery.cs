using BookManager.Application.ViewModels;
using MediatR;

namespace BookManager.Application.Queries.BooksQueries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<List<BookViewModel>>
    {
    }
}
