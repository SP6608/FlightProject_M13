namespace WebAppFligth.ViewModels
{
    public class ReservationIndexViewModel
    {
        public ICollection<ReservationViewModel> Reservations { get; set; }
          = new List<ReservationViewModel>();

        public string? Email { get; set; }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 10;
    }
}
