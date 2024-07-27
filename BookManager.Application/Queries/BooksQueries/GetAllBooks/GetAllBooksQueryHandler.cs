using BookManager.Application.Models;
using BookManager.Application.ViewModels;
using BookManager.Core.Repositories;
using MediatR;

namespace BookManager.Application.Queries.BooksQueries.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, ResultViewModel<List<BookViewModel>>>
    {
        private readonly IBookRepository _bookRepository;

        public GetAllBooksQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ResultViewModel<List<BookViewModel>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetAllAsync();

            var bookViewModel = book
                .Select(b => new BookViewModel(b.Id, b.Title, b.Author, b.ISBN, b.YearPublication))
                .ToList();

            return ResultViewModel<List<BookViewModel>>.Sucess(bookViewModel);
        }
    }
}
