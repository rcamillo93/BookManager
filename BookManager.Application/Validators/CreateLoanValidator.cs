using BookManager.Application.Commands.LoansCommands.CreateLoan;
using FluentValidation;

namespace BookManager.Application.Validators
{
    public class CreateLoanValidator : AbstractValidator<CreateLoanCommand>
    {
        public CreateLoanValidator()
        {
            RuleFor(l => l.IdUser)
                .NotEmpty()
                    .WithMessage("Informe o cliente para iniciar um empréstimo");

            RuleFor(l => l.IdBook)               
                .NotEmpty()
                    .WithMessage("Informe um livro");
        }
    }
}
