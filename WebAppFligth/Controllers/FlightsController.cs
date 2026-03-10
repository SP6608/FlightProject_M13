using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppFligth.Data;
using WebAppFligth.ViewModels;

namespace WebAppFligth.Controllers
{
    
    public class FlightsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public FlightsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IActionResult> AllFlights()
        {
            ICollection<FlightsViewModel> model = await dbContext.Flights
              .AsNoTracking()
              .Select(f => new FlightsViewModel()
              {
                  Id = f.Id,
                  From = f.From,
                  To = f.To,
                  DepartureTime = f.DepartureTime,
                  Duration = f.LandingTime - f.DepartureTime,
                  TypePlane = f.TypePlane,
                  PilotName = f.PilotName,
              })
              .ToListAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await dbContext.Flights
                .AsNoTracking()
                .Where(f => f.Id == id)
                .Select(f => new FlightDetailsViewModel
                {
                    Id = f.Id,
                    From = f.From,
                    To = f.To,
                    DepartureTime = f.DepartureTime,
                    LandingTime = f.LandingTime,
                    Duration = f.LandingTime - f.DepartureTime,
                    TypePlane = f.TypePlane,
                    PlaneNumber = f.PlaneNumber,
                    PilotName = f.PilotName,
                    EconomySeat = f.EconomySeat,
                    BusinessSeat = f.BusinessSeat
                })
                .FirstOrDefaultAsync();

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }
    }
}
