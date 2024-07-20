using BookManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManager.Infrastructure.Persistence.Configurations
{
    public class BookConfigurations : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(u => u.Titulo)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
