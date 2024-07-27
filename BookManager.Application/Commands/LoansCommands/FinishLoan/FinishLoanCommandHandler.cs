using BookManager.Core.Repositories;
using MediatR;

namespace BookManager.Application.Commands.LoansCommands.FinishLoan
{
    public class FinishLoanCommandHandler : IRequestHandler<FinishLoanCommand>
    {
        private readonly ILoanRepository _loanRepository;

        public FinishLoanCommandHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task Handle(FinishLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetLoanByIdAsync(request.Id);

            if (loan != null)
            {
                loan.DevolverLivro();
                await _loanRepository.SaveChangesAsync();
            }

        }
    }
}
