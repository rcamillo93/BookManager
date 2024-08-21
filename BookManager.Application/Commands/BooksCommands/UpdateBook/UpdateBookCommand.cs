using BookManager.Application.Models;
using MediatR;

namespace BookManager.Application.Commands.BooksCommands.UpdateBook
{
    public class UpdateBookCommand : IRequest<ResultViewModel>
    {
        public UpdateBookCommand(string title, string author, string iSBN, int yearPublication)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            YearPublication = yearPublication;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int YearPublication { get; set; }
    }
}
