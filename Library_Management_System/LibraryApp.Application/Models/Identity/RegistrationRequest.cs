using System.ComponentModel.DataAnnotations;

namespace BooApp.Application.Models.Identity
{
    public class RegistrationRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } 
        [Required]
        public string UserName { get; set; } 
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime MembershipDate { get; set; }
        [Required]
        public string Status { get; set; }

    }
}
