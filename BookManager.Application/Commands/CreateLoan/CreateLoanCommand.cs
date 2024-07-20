﻿using MediatR;

namespace BookManager.Application.Commands.CreateLoan
{
    public class CreateLoanCommand : IRequest
    {
        public CreateLoanCommand(int idBook, int idUser)
        {
            IdBook = idBook;
            IdUser = idUser;
        }

        public int IdBook { get; set; }
        public int IdUser { get; set; }
    }
}
