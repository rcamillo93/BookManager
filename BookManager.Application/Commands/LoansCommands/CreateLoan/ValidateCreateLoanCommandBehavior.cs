using BookManager.Application.Models;
using BookManager.Infrastructure.Persistence;
using MediatR;

namespace BookManager.Application.Commands.LoansCommands.CreateLoan
{
    public class ValidateCreateLoanCommandBehavior : IPipelineBehavior<CreateLoanCommand, ResultViewModel<int>>
    {
        private readonly BookDbContext _context;

        public ValidateCreateLoanCommandBehavior(BookDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<int>> Handle(CreateLoanCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var book = _context.Books.Any(b => b.Id == request.IdBook);

            var user = _context.Users.Where(u => u.Id == request.IdUser &&
                        u.Active && u.DateRestriction == null).Any();

            if(!book || !user)
            {
                return ResultViewModel<int>.Error("Usuário ou livro não encontrados.");
            }

            var bookAvailable = _context.Books.Where(b => b.Id == request.IdBook
                                && b.Available).Any();

            if(!book)
                return ResultViewModel<int>.Error("O livro não esta disponível para emprétismo");

            // chamada do handler
            return await next();
        }
    }
}
