using BookManager.Application.ViewModels;
using MediatR;

namespace BookManager.Application.Queries.LoansQueries.GetAllLoan
{
    public class GetAllLoansQuery : IRequest<List<LoanViewModel>>
    {
    }
}
