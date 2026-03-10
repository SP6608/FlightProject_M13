using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace WebAppFligth.ViewModels
{
    public class ReservationCreateViewModel
    {
        public int FlightId { get; set; }
        [BindNever]
        public string? FlightRoute { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        public List<PassengerInputViewModel> Passengers { get; set; }
            = new List<PassengerInputViewModel>();
    }
}
