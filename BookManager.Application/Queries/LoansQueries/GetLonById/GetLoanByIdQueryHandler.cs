using BookManager.Application.Models;
using BookManager.Application.ViewModels;
using BookManager.Core.Repositories;
using MediatR;

namespace BookManager.Application.Queries.LoansQueries.GetLonById
{
    public class GetLoanByIdQueryHandler : IRequestHandler<GetLoanByIdQuery, ResultViewModel<LoanViewModel>>
    {
        private readonly ILoanRepository _loanRepository;

        public GetLoanByIdQueryHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<ResultViewModel<LoanViewModel>> Handle(GetLoanByIdQuery request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetLoanByIdAsync(request.Id);

            if (loan == null)
                return ResultViewModel<LoanViewModel>.Error("Empréstimo não encontrado");

            var loanViewModel = new LoanViewModel(loan.Id, loan.LoanDate, loan.ExpectedDate,
                                loan.Client.Name, loan.Book.Title, loan.Returned);

            return ResultViewModel<LoanViewModel>.Sucess(loanViewModel);
        }
    }
}
