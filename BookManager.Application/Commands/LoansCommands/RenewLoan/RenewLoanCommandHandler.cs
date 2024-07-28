using BookManager.Application.Models;
using BookManager.Core.Repositories;
using MediatR;

namespace BookManager.Application.Commands.LoansCommands.RenewLoan
{
    public class RenewLoanCommandHandler : IRequestHandler<RenewLoanCommand, ResultViewModel>
    {
        private readonly ILoanRepository _loanRepository;

        public RenewLoanCommandHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<ResultViewModel> Handle(RenewLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetLoanByIdAsync(request.Id);

            if (loan == null)
                return ResultViewModel.Error("Empréstimo não encontado");

            loan.RenewLoan();
            await _loanRepository.SaveChangesAsync();

            return ResultViewModel.Sucess();
        }
    }
}
