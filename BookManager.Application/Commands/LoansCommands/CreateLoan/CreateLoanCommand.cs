using BookManager.Application.Models;
using MediatR;

namespace BookManager.Application.Commands.LoansCommands.CreateLoan
{
    public class CreateLoanCommand : IRequest<ResultViewModel<int>>
    {
        public CreateLoanCommand(int idBook, int idUser)
        {
            IdBook = idBook;
            IdUser = idUser;
        }

        public int IdBook { get; set; }
        public int IdUser { get; set; }
    }
}
