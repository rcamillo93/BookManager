using BookManager.Application.Models;
using BookManager.Application.ViewModels;
using BookManager.Core.Repositories;
using MediatR;

namespace BookManager.Application.Queries.UsersQueries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ResultViewModel<UserViewModel>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultViewModel<UserViewModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdSAsync(request.Id);

            if (user == null)
                return ResultViewModel<UserViewModel>.Error("Usuário não encontrado");

            var userViewModel = new UserViewModel(user.Id, user.Name, user.Email, user.DateRestriction);

            return ResultViewModel<UserViewModel>.Sucess(userViewModel);
        }
    }
}
