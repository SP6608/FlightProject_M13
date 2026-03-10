using System.ComponentModel.DataAnnotations;

namespace WebAppFligth.ViewModels
{
    public class FlightsViewModel
    {  
        public int Id { get; set; }
        public string From { get; set; } = null!;
        public string To { get; set; }= null!;
        public DateTime DepartureTime { get; set; }
        public TimeSpan Duration {  get; set; }
        public string TypePlane { get; set; } = null!;
        public string PilotName { get; set; }=null!;
    }
}
