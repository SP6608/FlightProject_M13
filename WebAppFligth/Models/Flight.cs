using System.ComponentModel.DataAnnotations;

namespace WebAppFligth.Models
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string From { get; set; } = null!;
        [Required]
        public string To { get; set; } = null!;
        [Required]
        public DateTime DepartureTime {  get; set; }
        [Required]
        public DateTime LandingTime { get; set; }
        public string TypePlane { get; set; } = null!;
        [Required]
        public string PlaneNumber { get; set; } = null!;
        [Required]
        public string PilotName { get; set; } = null!;
        public int EconomySeat { get; set; }
        public int BusinessSeat { get; set; }
        //Navigation
        public ICollection<Reservation> Reservations { get; set; }
        = new HashSet<Reservation>();

    }
}
