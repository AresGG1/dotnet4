using Bogus;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Seeders;

public class AircraftSeeder : ISeeder<Aircraft>
{
    public void Seed(EntityTypeBuilder<Aircraft> builder)
    {
        //Bogus data faker
        
        int id = 1;
        var aircraftFaker = new Faker<Aircraft>()
            .RuleFor(a => a.Id, f => id++)
            .RuleFor(a => a.Manufacturer, f =>
            {
                string compName = f.Company.CompanyName();
                return compName.Substring(0, Math.Min(compName.Length, 25));
            })
            .RuleFor(a => a.Model, f => f.Vehicle.Model())
            .RuleFor(a => a.Year, f => f.Random.Int(1965, 2023))
            .RuleFor(a => a.FlightHours, f => f.Random.Int(30, 2000));


        builder.HasData(aircraftFaker.Generate(10));
    }
}
