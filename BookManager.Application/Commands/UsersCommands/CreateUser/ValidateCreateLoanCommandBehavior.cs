using BookManager.Application.Models;
using BookManager.Infrastructure.Persistence;
using MediatR;

namespace BookManager.Application.Commands.UsersCommands.CreateUser
{
    public class ValidateCreateLoanCommandBehavior : IPipelineBehavior<CreateUserCommand, ResultViewModel<int>>
    {
        private readonly BookDbContext _context;

        public ValidateCreateLoanCommandBehavior(BookDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<int>> Handle(CreateUserCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var user = _context.Users.Any(u => u.Email == request.Email);

            if (user)
                return ResultViewModel<int>.Error("E-mail já cadastrado.");

            return await next();
        }
    }
}
