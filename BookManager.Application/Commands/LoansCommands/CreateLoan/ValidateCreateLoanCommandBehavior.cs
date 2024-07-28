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

            var user = _context.Users.Where(u => u.Active && u.DateRestriction == null)
                .Any(b => b.Id == request.IdUser);

            if(!book || !user)
            {
                return ResultViewModel<int>.Error("Usuário ou livro não encontrados.");
            }

            // chamada do handler
            return await next();
        }
    }
}
