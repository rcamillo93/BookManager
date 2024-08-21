using BookManager.Application.Models;
using BookManager.Core.Repositories;
using MediatR;

namespace BookManager.Application.Commands.BooksCommands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, ResultViewModel>
    {
        private readonly IBookRepository _bookRepository;

        public UpdateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ResultViewModel> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);

            if (book == null)
                return ResultViewModel.Error("Livro não encontrado.");

            book.Update(request.Title, request.Author, request.ISBN, request.YearPublication);

            await _bookRepository.SaveChangesAsync();

            return ResultViewModel.Sucess();
        }
    }
}
