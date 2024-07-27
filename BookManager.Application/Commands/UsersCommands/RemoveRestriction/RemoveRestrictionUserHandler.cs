using BookManager.Application.Models;
using BookManager.Core.Entities;
using BookManager.Core.Repositories;
using MediatR;

namespace BookManager.Application.Commands.UsersCommands.UpdateUser
{
    public class RemoveRestrictionUserHandler : IRequestHandler<RemoveRestrictionUserCommand, ResultViewModel>
    {
        private readonly IUserRepository _userRepository;

        public RemoveRestrictionUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultViewModel> Handle(RemoveRestrictionUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdSAsync(request.Id);
                        
            if (user == null)
                return ResultViewModel.Error("Usuário não encontrado");

            user.RemoveRestriction();

            return ResultViewModel.Sucess();
        }
    }
}
