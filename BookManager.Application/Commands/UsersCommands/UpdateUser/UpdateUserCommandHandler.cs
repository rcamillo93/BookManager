using BookManager.Application.Models;
using BookManager.Core.Entities;
using BookManager.Core.Repositories;
using MediatR;

namespace BookManager.Application.Commands.UsersCommands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResultViewModel>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdSAsync(request.Id);

            if (user == null)
                return ResultViewModel.Error("Usuário não encontrado");

            user.Update(request.Name, request.Email);

            await _userRepository.SaveChangesAsync();                     

            return ResultViewModel.Sucess();

        }
    }
}
