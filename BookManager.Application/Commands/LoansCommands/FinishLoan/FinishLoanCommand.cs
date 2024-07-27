using BookManager.Application.Models;
using MediatR;

namespace BookManager.Application.Commands.LoansCommands.FinishLoan
{
    public class FinishLoanCommand : IRequest<ResultViewModel>
    {
        public FinishLoanCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}