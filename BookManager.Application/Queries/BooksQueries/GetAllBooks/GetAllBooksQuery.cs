using BookManager.Application.Models;
using BookManager.Application.ViewModels;
using MediatR;

namespace BookManager.Application.Queries.BooksQueries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<ResultViewModel<List<BookViewModel>>>
    {
    }
}
