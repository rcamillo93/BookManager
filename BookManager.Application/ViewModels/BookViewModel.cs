namespace BookManager.Application.ViewModels
{
    public class BookViewModel
    {
        public BookViewModel(int id, string title, string author, string iSBN, int yearPublication, bool available)
        {
            Id = id;
            Title = title;
            Author = author;
            ISBN = iSBN;
            YearPublication = yearPublication;

            Available = available;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public int YearPublication { get; private set; }
        public bool Available { get; private set; }
    }
}
