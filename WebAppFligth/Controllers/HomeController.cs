using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppFligth.Data;
using WebAppFligth.ViewModels;


namespace WebAppFligth.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;

        public HomeController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            if (page < 1)
            {
                page = 1;
            }

            int totalFlights = await context.Flights.CountAsync();

            int totalPages = (int)Math.Ceiling(totalFlights / (double)pageSize);

            var flights = await context.Flights
                .OrderBy(f => f.DepartureTime)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(f => new FlightRowViewModel
                {
                    Id = f.Id,
                    From = f.From,
                    To = f.To,
                    DepartureTime = f.DepartureTime,
                    Duration = f.LandingTime - f.DepartureTime,
                    TypePlane = f.TypePlane
                })
                .ToListAsync();

            var model = new HomeIndexViewModel
            {
                Flights = flights,
                CurrentPage = page,
                TotalPages = totalPages,
                PageSize = pageSize
            };

            return View(model);
        }
    }
}