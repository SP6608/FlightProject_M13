using System.ComponentModel.DataAnnotations;
using WebAppFligth.Models;

namespace WebAppFligth.ViewModels
{
    public class PassengerInputViewModel
    {
        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string MiddleName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string Egn { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public string Nationality { get; set; } = null!;

        [Required]
        public TicketType TicketType { get; set; }
    }
}
