using BookManager.Core.Entities;
using BookManager.Core.Repositories;
using MediatR;

namespace BookManager.Application.Commands.CreateBook
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
            var book = new Book(request.Titulo, request.Autor, request.ISBN, request.AnoPublicacao);
            await _bookRepository.AddAsync(book);          
        }
    }
}
