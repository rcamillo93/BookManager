using BookManager.Application.Models;
using BookManager.Core.Enums;
using BookManager.Infrastructure.Persistence;
using MediatR;

namespace BookManager.Application.Commands.LoansCommands.FinishLoan
{
    public class ValidateFinishLoanCommandBehavior : IPipelineBehavior<FinishLoanCommand, ResultViewModel>
    {
        private readonly BookDbContext _dbContext;

        public ValidateFinishLoanCommandBehavior(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResultViewModel> Handle(FinishLoanCommand request, RequestHandlerDelegate<ResultViewModel> next, CancellationToken cancellationToken)
        {
            var loan = _dbContext.Loans.Where(l => l.Id == request.Id
                        && (l.Status == LoanStatusEnun.Active || l.Status == LoanStatusEnun.Renovated
                            || l.Status == LoanStatusEnun.Late)).Any();

            if (!loan)
                return ResultViewModel.Error("Empréstimo não existe ou já foi finalizado");

            var result = await next();

            if (result.IsSuccess)
            {
                // envia o e-mail
            }

            return result;
        }
    }
}
