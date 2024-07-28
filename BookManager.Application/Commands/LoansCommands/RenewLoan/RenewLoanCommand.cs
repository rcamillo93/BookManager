using BookManager.Application.Models;
using MediatR;

namespace BookManager.Application.Commands.LoansCommands.RenewLoan
{
    public class RenewLoanCommand : IRequest<ResultViewModel>
    {
        public RenewLoanCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
