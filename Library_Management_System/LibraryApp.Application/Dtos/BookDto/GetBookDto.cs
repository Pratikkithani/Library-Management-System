using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Domain;

namespace LibraryApp.Application.Dtos.BookDto
{
    public class GetBookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public int PublishedYear { get; set; }
        public int CopiesAvailable { get; set; }

        public string? Name { get; set; } // ✅ Replace Category with this

    }
}
