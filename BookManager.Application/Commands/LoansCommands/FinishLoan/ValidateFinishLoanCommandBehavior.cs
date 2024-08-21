using BookManager.Application.Models;
using BookManager.Core.Enums;
using BookManager.Core.Services;
using BookManager.Infrastructure.Persistence;
using MediatR;

namespace BookManager.Application.Commands.LoansCommands.FinishLoan
{
    public class ValidateFinishLoanCommandBehavior : IPipelineBehavior<FinishLoanCommand, ResultViewModel>
    {
        private readonly BookDbContext _dbContext;
        private readonly ISendEmailService _sendEmailService;

        public ValidateFinishLoanCommandBehavior(BookDbContext dbContext, ISendEmailService sendEmailService)
        {
            _dbContext = dbContext;
            _sendEmailService = sendEmailService;
        }

        public async Task<ResultViewModel> Handle(FinishLoanCommand request, RequestHandlerDelegate<ResultViewModel> next, CancellationToken cancellationToken)
        {
            var loan = _dbContext.Loans.Any(l => l.Id == request.Id
                        && (l.Status == LoanStatusEnun.Active || l.Status == LoanStatusEnun.Renovated
                            || l.Status == LoanStatusEnun.Late));

            if (!loan)
                return ResultViewModel.Error("Empréstimo não existe ou já foi finalizado");

            var result = await next();

            if (result.IsSuccess)
                await _sendEmailService.FinishLoanEmail(request.Id);
                
            return result;
        }
    }
}
