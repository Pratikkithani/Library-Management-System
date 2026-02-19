using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Configuration
{
    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book
                {
                    BookId = 1,
                    Title = "Title",
                    Author = "Author",
                    ISBN = "boo1",
                    CategoryId = 1,
                    PublishedYear = 1990,
                    CopiesAvailable = 5
                });

        }
    }
}
