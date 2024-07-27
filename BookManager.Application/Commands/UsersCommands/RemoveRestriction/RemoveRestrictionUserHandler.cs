using BookManager.Core.Repositories;
using MediatR;

namespace BookManager.Application.Commands.UsersCommands.UpdateUser
{
    public class RemoveRestrictionUserHandler : IRequestHandler<RemoveRestrictionUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public RemoveRestrictionUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(RemoveRestrictionUserCommand request, CancellationToken cancellationToken)
        {
           
        }
    }
}
