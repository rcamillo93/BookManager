using BookManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManager.Infrastructure.Persistence.Configurations
{
    public class LoanConfigurations : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder
                .HasKey(l => l.Id);

            builder.HasOne(b => b.Book)
                .WithMany(b => b.LoansBook)
                .HasForeignKey(b => b.IdBook)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(u => u.Client)
                .WithMany(u => u.LoansUser)
                .HasForeignKey(u => u.IdUser)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
