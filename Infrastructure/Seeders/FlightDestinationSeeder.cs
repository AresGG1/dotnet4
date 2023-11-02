using Bogus;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Seeders;

public class FlightDestinationSeeder : ISeeder<FlightDestination>
{
    public void Seed(EntityTypeBuilder<FlightDestination> builder)
    {
        int id = 1;
        var aircraftFaker = new Faker<FlightDestination>()
            .RuleFor(f => f.Id, f => id++)
            .RuleFor(f => f.TicketPrice, f => f.Random.Decimal(min: 10, max: 400))
            .RuleFor(f => f.Start, f => f.Date.Recent(100))
            .RuleFor(f => f.AircraftId, f => f.Random.Int(1, 10));


        builder.HasData(aircraftFaker.Generate(10));
    }
}
