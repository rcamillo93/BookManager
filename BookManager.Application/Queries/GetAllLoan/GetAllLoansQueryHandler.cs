using BookManager.Application.ViewModels;
using BookManager.Core.Repositories;
using MediatR;

namespace BookManager.Application.Queries.GetAllLoan
{
    public class GetAllLoansQueryHandler : IRequestHandler<GetAllLoansQuery, List<LoanViewModel>>
    {
        private readonly ILoanRepository _loanRepository;

        public GetAllLoansQueryHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<List<LoanViewModel>> Handle(GetAllLoansQuery request, CancellationToken cancellationToken)
        {
            var loans = await _loanRepository.GetAllLoanAsync();

            var loanViewModel = loans
                .Select(l => new LoanViewModel(l.Id, l.DataEmprestimo, l.DataPrevista, l.Cliente.Nome, l.Book.Titulo))
                .ToList();

            return loanViewModel;
        }
    }
}
