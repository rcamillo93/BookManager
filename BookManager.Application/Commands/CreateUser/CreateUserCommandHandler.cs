using BookManager.Core.Entities;
using BookManager.Core.Repositories;
using MediatR;

namespace BookManager.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Nome, request.Email);
            await _userRepository.AddAsync(user);
        }
    }
}
