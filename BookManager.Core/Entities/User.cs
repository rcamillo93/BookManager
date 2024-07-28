namespace BookManager.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string name, string email)
        {
            Name = name;
            Email = email;
            Active = true;
            CreatedAt = DateTime.Now;           
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime? DateRestriction { get; private set; }
        public int NumberOfRestrictions { get; set; }
        public bool Active { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public List<Loan> LoansUser { get; private set; }
               

        public void SetRestriction()
        {
            DateRestriction = DateTime.Now.AddDays(14);
            NumberOfRestrictions++;

            if(NumberOfRestrictions >= 3)
            {
                Active = false;
                DateRestriction = DateTime.Now;
            }
                
        }

        public void RemoveRestriction()
        {
            DateRestriction = null;
        }
    }
}
