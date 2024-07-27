using BookManager.Application.ViewModels;
using BookManager.Core.Repositories;
using MediatR;

namespace BookManager.Application.Queries.LoansQueries.GetLonById
{
    public class GetLoanByIdQueryHandler : IRequestHandler<GetLoanByIdQuery, LoanViewModel?>
    {
        private readonly ILoanRepository _loanRepository;

        public GetLoanByIdQueryHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<LoanViewModel?> Handle(GetLoanByIdQuery request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetLoanByIdAsync(request.Id);

            if (loan == null)
                return null;

            var loanViewModel = new LoanViewModel(loan.Id, loan.LoanDate, loan.ExpectedDate,
                                loan.Client.Name, loan.Book.Title);
            return loanViewModel;
        }
    }
}
