using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CustomerOrdersApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
