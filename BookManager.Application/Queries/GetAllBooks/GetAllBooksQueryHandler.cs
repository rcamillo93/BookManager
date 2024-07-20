using BookManager.Application.ViewModels;
using BookManager.Core.Repositories;
using MediatR;

namespace BookManager.Application.Queries.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<BookViewModel>>
    {
        private readonly IBookRepository _bookRepository;

        public GetAllBooksQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<BookViewModel>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetAllAsync();

            var bookViewModel = book
                .Select(b => new BookViewModel(b.Id, b.Titulo, b.Autor, b.ISBN, b.AnoPublicacao))
                .ToList();
            return bookViewModel;
        }
    }
}
