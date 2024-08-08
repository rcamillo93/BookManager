using BookManager.Application.Commands.BooksCommands.CreateBook;
using BookManager.Application.Commands.LoansCommands.CreateLoan;
using BookManager.Application.Commands.LoansCommands.FinishLoan;
using BookManager.Application.Commands.LoansCommands.RenewLoan;
using BookManager.Application.Models;
using BookManager.Core.Repositories;
using BookManager.Infrastructure.Persistence.Repositories;
using BookManager.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookManager.Application
{
    public static class ApplicationModule 
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddHandlers()
                .AddRepositories(configuration);

            return services;
        }

     
        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(config =>
                config.RegisterServicesFromAssemblyContaining<CreateBookCommand>());

            services.AddTransient<IPipelineBehavior<CreateLoanCommand, ResultViewModel<int>>, ValidateCreateLoanCommandBehavior>();

            services.AddTransient<IPipelineBehavior<FinishLoanCommand, ResultViewModel>, ValidateFinishLoanCommandBehavior>();

            services.AddTransient<IPipelineBehavior<RenewLoanCommand, ResultViewModel>, ValidateRenewLoanCommandBehavior>();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("LibraryCs")));

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();

            return services;
        }

    }
}
