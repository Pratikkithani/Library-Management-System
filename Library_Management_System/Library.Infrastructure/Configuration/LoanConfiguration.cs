using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualBasic;

namespace Library.Infrastructure.Configuration
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.HasData(
                new Loan
                {
                    LoanId = 1,
                    BookId = 1,
                    MemberId=1,
                    LoanDate = new DateTime(2025, 3, 28), 
                    DueDate = new DateTime(2025, 4, 28), 
                    ReturnDate = new DateTime(2025, 4, 15), 
                    Status = "Burrowed"
                });
        }
    }
}
