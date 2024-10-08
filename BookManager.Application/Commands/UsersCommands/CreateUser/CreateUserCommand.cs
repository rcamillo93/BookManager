﻿using BookManager.Application.Models;
using MediatR;

namespace BookManager.Application.Commands.UsersCommands.CreateUser
{
    public class CreateUserCommand : IRequest<ResultViewModel<int>>
    {
        public CreateUserCommand(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; set; }
        public string Email { get; set; }
    }
}
