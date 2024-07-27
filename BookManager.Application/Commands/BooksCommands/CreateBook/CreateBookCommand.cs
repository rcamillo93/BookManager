using MediatR;

namespace BookManager.Application.Commands.BooksCommands.CreateBook
{
    public class CreateBookCommand : IRequest
    {
        public CreateBookCommand(string title, string author, string iSBN, int yearPublication)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            YearPublication = yearPublication;
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int YearPublication { get; set; }
    }
}
