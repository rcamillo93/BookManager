using BookManager.Application.Models;
using BookManager.Application.ViewModels;
using BookManager.Core.Repositories;
using MediatR;

namespace BookManager.Application.Queries.BooksQueries.FindBookByTitle
{
    public class FindBookQueryHandler : IRequestHandler<FindBookQuery, ResultViewModel<List<BookViewModel>>>
    {
        private readonly IBookRepository _bookRepository;

        public FindBookQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ResultViewModel<List<BookViewModel>>> Handle(FindBookQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.FindBooksAsync(request.Title, request.Author);

            var bookViewModel = book.Select(b => new BookViewModel(b.Id, b.Title, b.Author, b.ISBN, b.YearPublication, b.Available))
                .ToList();

            return ResultViewModel<List<BookViewModel>>.Sucess(bookViewModel);
        }
    }
}
