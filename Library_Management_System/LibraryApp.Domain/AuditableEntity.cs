using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain
{
    public class AuditableEntity
    {
        public string? CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }

        public string? UpdatedById { get; set; } 
        public DateTime? UpdatedOn { get; set; }

    }
}
