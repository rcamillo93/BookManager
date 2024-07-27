using BookManager.Application.Models;
using BookManager.Application.ViewModels;
using MediatR;

namespace BookManager.Application.Queries.LoansQueries.GetAllLoan
{
    public class GetAllLoansQuery : IRequest<ResultViewModel<List<LoanViewModel>>>
    {
    }
}
