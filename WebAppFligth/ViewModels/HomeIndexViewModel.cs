namespace WebAppFligth.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<FlightRowViewModel> Flights { get; set; }
            = new List<FlightRowViewModel>();

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int PageSize { get; set; }
    }

    public class FlightRowViewModel
    {
        public int Id { get; set; }

        public string From { get; set; } = null!;

        public string To { get; set; } = null!;

        public DateTime DepartureTime { get; set; }

        public TimeSpan Duration { get; set; }

        public string TypePlane { get; set; } = null!;
    }
}
