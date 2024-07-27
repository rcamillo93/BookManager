using BookManager.Application.Models;
using MediatR;

namespace BookManager.Application.Commands.LoansCommands.CreateLoan
{
    public class ValidateCreateLoanCommandBehavior : IPipelineBehavior<CreateLoanCommand, ResultViewModel>
    {
        public Task<ResultViewModel> Handle(CreateLoanCommand request, RequestHandlerDelegate<ResultViewModel> next, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
