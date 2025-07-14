using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryApp.Domain
{
    public class Book : AuditableEntity
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public int PublishedYear { get; set; }
        public int CopiesAvailable { get; set; }
        public Category? Category { get; set; }
    }
}
