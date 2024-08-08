using BookManager.Application.Models;
using BookManager.Application.ViewModels;
using MediatR;

namespace BookManager.Application.Queries.BooksQueries.FindBookByTitle
{
    public class FindBookQuery : IRequest<ResultViewModel<List<BookViewModel>>>
    {
        public FindBookQuery(string? title, string? author)
        {
            Title = title;
            Author = author;
        }

        public string? Title { get; }
        public string? Author { get; }
    }
}
