using BookManager.Application.Commands.UsersCommands.UpdateUser;
using FluentValidation;

namespace BookManager.Application.Validators
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
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
