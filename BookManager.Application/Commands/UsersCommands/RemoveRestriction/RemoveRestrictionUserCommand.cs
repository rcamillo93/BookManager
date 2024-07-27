using BookManager.Application.Models;
using MediatR;

namespace BookManager.Application.Commands.UsersCommands.UpdateUser
{
    public class RemoveRestrictionUserCommand : IRequest<ResultViewModel>
    {
        public RemoveRestrictionUserCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
