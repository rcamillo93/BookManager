using BookManager.Application.Models;
using MediatR;

namespace BookManager.Application.Commands.UsersCommands.UpdateUser
{
    public class UpdateUserCommand : IRequest<ResultViewModel>
    {
        public UpdateUserCommand(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
