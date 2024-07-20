using BookManager.Core.Entities;
using BookManager.Core.Repositories;
using MediatR;

namespace BookManager.Application.Commands.CreateLoan
{
    public class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand>
    {
        private readonly ILoanRepository _loanRepository;

        public CreateLoanCommandHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = new Loan(request.IdUser, request.IdBook);
            await _loanRepository.AddAsync(loan);
        }
    }
}
