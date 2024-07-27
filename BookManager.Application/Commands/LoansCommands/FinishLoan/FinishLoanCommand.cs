using MediatR;

namespace BookManager.Application.Commands.LoansCommands.FinishLoan
{
    public class FinishLoanCommand : IRequest
    {
        public FinishLoanCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}