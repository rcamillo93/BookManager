using BookManager.Application.Models;
using BookManager.Core.Entities;
using BookManager.Core.Services;
using BookManager.Infrastructure.Persistence;
using MediatR;

namespace BookManager.Application.Commands.LoansCommands.CreateLoan
{
    public class ValidateCreateLoanCommandBehavior : IPipelineBehavior<CreateLoanCommand, ResultViewModel<int>>
    {
        private readonly BookDbContext _context;
        private readonly ISendEmailService _sendEmailService;

        public ValidateCreateLoanCommandBehavior(BookDbContext context, ISendEmailService sendEmailService)
        {
            _context = context;
            _sendEmailService = sendEmailService;
        }

        public async Task<ResultViewModel<int>> Handle(CreateLoanCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var book = _context.Books.Any(b => b.Id == request.IdBook);
                        
            var user = _context.Users.Any(u => u.Id == request.IdUser &&
                        u.Active && u.DateRestriction == null);

            if (!book || !user)
            {
                return ResultViewModel<int>.Error("Usuário ou livro não encontrados.");
            }

            var bookAvailable = _context.Books.Any(b => b.Id == request.IdBook
                                && b.Available);

            if(!book)
                return ResultViewModel<int>.Error("O livro não esta disponível para emprétismo");

            // chamada do handler
            var result = await next();

            if (result.IsSuccess)
                await _sendEmailService.CreateLoanEmail(result.Data);

            return result;
        }
    }
}
