using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppFligth.Models;

namespace WebAppFligth.Common
{
    public class FlightTypeConfiguration : IEntityTypeConfiguration<Flight>
    {
            private readonly ICollection<Flight> Flights =
            new HashSet<Flight>() 
            { 
            new Flight
            {
            Id = 1,
            From = "Sofia",
            To = "London",
            DepartureTime = new DateTime(2026, 4, 10, 8, 30, 0),
            LandingTime = new DateTime(2026, 4, 10, 11, 30, 0),
            TypePlane = "Airbus A320",
            PlaneNumber = "LZ-A320",
            PilotName = "Ivan Petrov",
            EconomySeat = 150,
            BusinessSeat = 20
            },

new Flight
    {
    Id = 2,
    From = "Sofia",
    To = "Berlin",
    DepartureTime = new DateTime(2026, 4, 12, 14, 15, 0),
    LandingTime = new DateTime(2026, 4, 12, 16, 15, 0),
    TypePlane = "Boeing 737",
    PlaneNumber = "LZ-B737",
    PilotName = "Georgi Ivanov",
    EconomySeat = 140,
    BusinessSeat = 18
    },

new Flight
    {
    Id = 3,
    From = "Sofia",
    To = "Paris",
    DepartureTime = new DateTime(2026, 4, 15, 9, 45, 0),
    LandingTime = new DateTime(2026, 4, 15, 12, 15, 0),
    TypePlane = "Airbus A321",
    PlaneNumber = "LZ-A321",
    PilotName = "Dimitar Kolev",
    EconomySeat = 160,
    BusinessSeat = 22
    },

new Flight
    {
    Id = 4,
    From = "Sofia",
    To = "Rome",
    DepartureTime = new DateTime(2026, 4, 18, 7, 20, 0),
    LandingTime = new DateTime(2026, 4, 18, 9, 10, 0),
    TypePlane = "Airbus A320",
    PlaneNumber = "LZ-A322",
    PilotName = "Petar Stoyanov",
    EconomySeat = 150,
    BusinessSeat = 20
    },

new Flight
    {
    Id = 5,
    From = "Sofia",
    To = "Madrid",
    DepartureTime = new DateTime(2026, 4, 20, 13, 0, 0),
    LandingTime = new DateTime(2026, 4, 20, 16, 30, 0),
    TypePlane = "Boeing 737",
    PlaneNumber = "LZ-B738",
    PilotName = "Nikolay Dimitrov",
    EconomySeat = 155,
    BusinessSeat = 20
    }
   };
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasData(Flights);
        }
    }
}
