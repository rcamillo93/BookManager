﻿using BookManager.Application.ViewModels;
using MediatR;

namespace BookManager.Application.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<BookViewModel?>
    {
        public GetBookByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
