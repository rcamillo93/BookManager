using BookManager.Application.Commands.BooksCommands.UpdateBook;
using FluentValidation;

namespace BookManager.Application.Validators
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(b => b.Author)
                .NotEmpty()
                .NotNull()
                    .WithMessage("O nome Autor é obrigatório")
                .MaximumLength(80)
                    .WithMessage("O tamanho máximo do campo Autor é 80 caracteres");

            RuleFor(b => b.YearPublication)
                .NotNull();

            RuleFor(b => b.Title)
                .NotEmpty()
                .NotNull()
                    .WithMessage("O nome titulo é obrigatório")
                .MaximumLength(150)
                    .WithMessage("O tamanho máximo do campo Titulo é 150 caracteres");
        }
    }
}
