using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppFligth.Data;
using WebAppFligth.Models;
using WebAppFligth.ViewModels;

namespace WebAppFligth.Controllers
{
    [Authorize]
    public class ReservationsController : Controller
    {
        private readonly ApplicationDbContext context;

        public ReservationsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? email, int page = 1, int pageSize = 10)
        {
            if (page < 1)
            {
                page = 1;
            }

            if (pageSize <= 0)
            {
                pageSize = 10;
            }

            var query = context.Reservations
                .AsNoTracking()
                .Include(r => r.Flight)
                .Include(r => r.Passegers)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(email))
            {
                query = query.Where(r => r.Email.Contains(email));
            }

            int totalReservations = await query.CountAsync();
            int totalPages = (int)Math.Ceiling(totalReservations / (double)pageSize);

            var reservations = await query
                .OrderByDescending(r => r.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(r => new ReservationViewModel
                {
                    Id = r.Id,
                    Email = r.Email,
                    IsConfirmed = r.IsConfirmed,
                    FlightRoute = r.Flight!.From + " - " + r.Flight.To,
                    DepartureTime = r.Flight.DepartureTime,
                    PassengersCount = r.Passegers.Count
                })
                .ToListAsync();

            var model = new ReservationIndexViewModel
            {
                Reservations = reservations,
                Email = email,
                CurrentPage = page,
                TotalPages = totalPages,
                PageSize = pageSize
            };

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Create(int flightId)
        {
            var flight = await context.Flights
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == flightId);

            if (flight == null)
            {
                return NotFound();
            }

            var model = new ReservationCreateViewModel
            {
                FlightId = flight.Id,
                FlightRoute = $"{flight.From} - {flight.To}",
                Passengers = new List<PassengerInputViewModel>
                {
                    new PassengerInputViewModel()
                }
            };

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReservationCreateViewModel model)
        {
            var flight = await context.Flights
                .FirstOrDefaultAsync(f => f.Id == model.FlightId);

            if (flight == null)
            {
                return NotFound();
            }

            if (model.Passengers == null || model.Passengers.Count == 0)
            {
                ModelState.AddModelError(string.Empty, "Трябва да има поне един пътник.");
            }

            if (!ModelState.IsValid)
            {
                model.FlightRoute = $"{flight.From} - {flight.To}";
                return View(model);
            }

            var reservation = new Reservation
            {
                Email = model.Email,
                FlightId = model.FlightId,
                IsConfirmed = true,
                Passegers = model.Passengers.Select(p => new Passenger
                {
                    FirstName = p.FirstName,
                    MiddleName = p.MiddleName,
                    LastName = p.LastName,
                    Egn = p.Egn,
                    PhoneNumber = p.PhoneNumber,
                    Nationality = p.Nationality,
                    TicketType = p.TicketType
                }).ToList()
            };

            context.Reservations.Add(reservation);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await context.Reservations
                .AsNoTracking()
                .Include(r => r.Flight)
                .Include(r => r.Passegers)
                .Where(r => r.Id == id)
                .Select(r => new ReservationDetailsViewModel
                {
                    Id = r.Id,
                    Email = r.Email,
                    IsConfirmed = r.IsConfirmed,
                    FlightRoute = r.Flight!.From + " - " + r.Flight.To,
                    DepartureTime = r.Flight.DepartureTime,
                    Passengers = r.Passegers.Select(p => new PassengerDetailsViewModel
                    {
                        FirstName = p.FirstName,
                        MiddleName = p.MiddleName,
                        LastName = p.LastName,
                        Egn = p.Egn,
                        PhoneNumber = p.PhoneNumber,
                        Nationality = p.Nationality,
                        TicketType = p.TicketType.ToString()
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var reservation = await context.Reservations
                .Include(r => r.Flight)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (reservation == null)
            {
                return NotFound();
            }

            var model = new ReservationViewModel
            {
                Id = reservation.Id,
                Email = reservation.Email,
                IsConfirmed = reservation.IsConfirmed,
                FlightRoute = reservation.Flight!.From + " - " + reservation.Flight.To,
                DepartureTime = reservation.Flight.DepartureTime,
                PassengersCount = reservation.Passegers.Count
            };

            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservation = await context.Reservations
                .Include(r => r.Passegers)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (reservation == null)
            {
                return NotFound();
            }

            context.Reservations.Remove(reservation);

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}