using MediatR;

namespace BookManager.Application.Commands.UsersCommands.UpdateUser
{
    public class RemoveRestrictionUserCommand : IRequest
    {
        public RemoveRestrictionUserCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
