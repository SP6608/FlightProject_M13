using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebAppFligth.Models
{
    public class AppUser:IdentityUser
    {
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public string Egn { get; set; } = null!;
        [Required]
        public string Address { get; set; } = null!;
    }
}
