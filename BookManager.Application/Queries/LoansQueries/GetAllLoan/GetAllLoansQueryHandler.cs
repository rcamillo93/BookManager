using BookManager.Application.Models;
using BookManager.Application.ViewModels;
using BookManager.Core.Repositories;
using MediatR;

namespace BookManager.Application.Queries.LoansQueries.GetAllLoan
{
    public class GetAllLoansQueryHandler : IRequestHandler<GetAllLoansQuery, ResultViewModel<List<LoanViewModel>>>
    {
        private readonly ILoanRepository _loanRepository;

        public GetAllLoansQueryHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<ResultViewModel<List<LoanViewModel>>> Handle(GetAllLoansQuery request, CancellationToken cancellationToken)
        {
            var loans = await _loanRepository.GetAllLoanAsync();

            var loanViewModel = loans
                .Select(l => new LoanViewModel(l.Id, l.LoanDate, l.ExpectedDate, l.Client.Name, l.Book.Title))
                .ToList();

            return ResultViewModel<List<LoanViewModel>>.Sucess(loanViewModel);
        }
    }
}
