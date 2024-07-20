﻿using BookManager.Core.Entities;
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
                .WithOne(b => b.LoanBook);

            builder
                .HasOne(u => u.Cliente)
                .WithMany(u => u.LoansUser)
                .HasForeignKey(u => u.IdUsuario);
        }
    }
}
