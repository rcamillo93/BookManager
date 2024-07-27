using BookManager.Application.Models;
using BookManager.Application.ViewModels;
using MediatR;

namespace BookManager.Application.Queries.LoansQueries.GetLonById
{
    public class GetLoanByIdQuery : IRequest<ResultViewModel<LoanViewModel>>
    {
        public GetLoanByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
