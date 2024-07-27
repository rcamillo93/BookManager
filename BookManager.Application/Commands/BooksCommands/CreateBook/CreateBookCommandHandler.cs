using BookManager.Core.Entities;
using BookManager.Core.Repositories;
using MediatR;

namespace BookManager.Application.Commands.BooksCommands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand>
    {
        private readonly IBookRepository _bookRepository;

        public CreateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book(request.Title, request.Author, request.ISBN, request.YearPublication);
            await _bookRepository.AddAsync(book);
        }
    }
}
