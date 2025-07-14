using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Domain;
using Microsoft.AspNetCore.Identity;

namespace BookApp.Identity.Model
{
    internal class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public int MemberId { get; set; }
        //public Member Member { get; set; }
    }
}
