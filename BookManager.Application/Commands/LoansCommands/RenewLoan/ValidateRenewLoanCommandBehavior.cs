using BookManager.Application.Models;
using BookManager.Core.Enums;
using BookManager.Core.Services;
using BookManager.Infrastructure.Notifications;
using BookManager.Infrastructure.Persistence;
using MediatR;

namespace BookManager.Application.Commands.LoansCommands.RenewLoan
{
    public class ValidateRenewLoanCommandBehavior : IPipelineBehavior<RenewLoanCommand, ResultViewModel>
    {
        private readonly BookDbContext _dbContext;
        private readonly ISendEmailService _sendEmailService;

        public ValidateRenewLoanCommandBehavior(BookDbContext dbContext, ISendEmailService sendEmailService)
        {
            _dbContext = dbContext;
            _sendEmailService = sendEmailService;
        }

        public async Task<ResultViewModel> Handle(RenewLoanCommand request, RequestHandlerDelegate<ResultViewModel> next, CancellationToken cancellationToken)
        {
            var loan = _dbContext.Loans.Any(l => l.Id == request.Id
                        && l.Status == LoanStatusEnun.Active && l.ExpectedDate < DateTime.Now);

            if (!loan)
                return ResultViewModel.Error("Só é permitido renovar empréstimos ativos que não estejam com atrasos");

            // chamada do handler
            var result = await next();

            if (result.IsSuccess)            
                await _sendEmailService.RenewLoanEmail(request.Id);         

            return result;
        }
    }
}
