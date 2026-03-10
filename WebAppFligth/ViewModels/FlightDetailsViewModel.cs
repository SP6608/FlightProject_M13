namespace WebAppFligth.ViewModels
{
    public class FlightDetailsViewModel
    {
        public int Id { get; set; }
        public string From { get; set; } = null!;
        public string To { get; set; } = null!;
        public DateTime DepartureTime { get; set; }
        public DateTime LandingTime { get; set; }
        public TimeSpan Duration { get; set; }
        public string TypePlane { get; set; } = null!;
        public string PlaneNumber { get; set; } = null!;
        public string PilotName { get; set; } = null!;
        public int EconomySeat { get; set; }
        public int BusinessSeat { get; set; }
    }
}
