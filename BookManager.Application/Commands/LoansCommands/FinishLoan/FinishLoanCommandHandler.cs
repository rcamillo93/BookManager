using BookManager.Application.Models;
using BookManager.Core.Repositories;
using MediatR;

namespace BookManager.Application.Commands.LoansCommands.FinishLoan
{
    public class FinishLoanCommandHandler : IRequestHandler<FinishLoanCommand, ResultViewModel>
    {
        private readonly ILoanRepository _loanRepository;

        public FinishLoanCommandHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<ResultViewModel> Handle(FinishLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetLoanByIdAsync(request.Id);

            if (loan == null)
                return ResultViewModel.Error("Empréstimo não existe.");

            loan.DevolverLivro();
            await _loanRepository.SaveChangesAsync();

            return ResultViewModel.Sucess();
        }
    }
}
