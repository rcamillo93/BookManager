using BookManager.Application.Commands.UsersCommands.CreateUser;
using FluentValidation;

namespace BookManager.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("O e-mail é inválido");

            RuleFor(u => u.Name)                
                .NotEmpty()
                    .WithMessage("O nome é obrigatório");
        }
    }
}
