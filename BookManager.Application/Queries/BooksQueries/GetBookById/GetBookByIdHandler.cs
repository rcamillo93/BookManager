using BookManager.Application.ViewModels;
using BookManager.Core.Repositories;
using MediatR;

namespace BookManager.Application.Queries.BooksQueries.GetBookById
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, BookViewModel?>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookByIdHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookViewModel?> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);

            if (book == null)
                return null;

            var bookViewModel = new BookViewModel(book.Id, book.Title, book.Author, book.ISBN, book.YearPublication);

            return bookViewModel;
        }
    }
}
