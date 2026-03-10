namespace WebAppFligth.ViewModels
{
    public class ReservationDetailsViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public bool IsConfirmed { get; set; }
        public string FlightRoute { get; set; } = null!;
        public DateTime DepartureTime { get; set; }

        public ICollection<PassengerDetailsViewModel> Passengers { get; set; }
            = new List<PassengerDetailsViewModel>();
    }
}
