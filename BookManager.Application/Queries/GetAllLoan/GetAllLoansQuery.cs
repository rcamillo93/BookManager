using BookManager.Application.ViewModels;
using MediatR;

namespace BookManager.Application.Queries.GetAllLoan
{
    public class GetAllLoansQuery : IRequest<List<LoanViewModel>>
    {
    }
}
