using BookManager.Application.Commands.UsersCommands.CreateUser;
using FluentValidation;

namespace BookManager.Application.Validators
{
    public class CreateUserCommandValidador : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidador()
        {
            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("O e-mail é inválido");
        }
    }
}
