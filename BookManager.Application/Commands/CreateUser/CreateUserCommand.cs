using MediatR;

namespace BookManager.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public CreateUserCommand(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
