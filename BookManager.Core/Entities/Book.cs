namespace BookManager.Core.Entities
{
    public class Book : BaseEntity
    {
        public Book(string title, string author, string iSBN, int yearPublication)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            YearPublication = yearPublication;
            Available = true;

            CreatedAt = DateTime.Now;
        }

        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public int YearPublication { get; private set; }
        public bool Available { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public List<Loan> LoansBook { get; private set; }

        public void AtualizarStatus(bool status)
        {
            Available = status;
        }
    }
}
