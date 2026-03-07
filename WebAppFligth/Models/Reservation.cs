using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppFligth.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        public bool IsConfirmed { get; set; }
        //Navigation
        [ForeignKey(nameof(Flight))]
        public int FlightId { get; set; }
       
        public Flight? Flight { get; set; }
        public ICollection<Passenger> Passegers {  get; set; }
        =new List<Passenger>();
    }
}
