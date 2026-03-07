using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppFligth.Models
{
    public class Passenger
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string LastName { get; set; }=null!;
        public string Egn { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Nationality { get; set; } = null!;
        public TicketType TicketType { get; set; }
        //Navigation
        [ForeignKey(nameof(Reservation))]
        public int ReservationId { get; set; }
        public Reservation? Reservation { get; set; }
    }
    public enum TicketType
    {
        Economy = 1,
        Business = 2
    }
}
