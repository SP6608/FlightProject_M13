using System.ComponentModel.DataAnnotations;

namespace WebAppFligth.Models
{
    public class VacationRequest
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime CreatedOn { get; set; }= DateTime.Now;
        public bool IsHalfDay {  get; set; }
        public bool IsApproved { get; set; }
        public VacationType VacationType { get; set; }
        //navigation
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
    public enum VacationType
    {
      PaidLeave,
      UnpaidLeave,
      SickLeave,
    }
}
