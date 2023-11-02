using Domain.Models;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AirportDatabaseContext : DbContext
{
    public DbSet<FlightDestination> FlightDestinations { get; set; }
    public DbSet<Aircraft> Aircrafts { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new AircraftConfiguration());
        modelBuilder.ApplyConfiguration(new FlightDestinationConfiguration());
    }
    
    public AirportDatabaseContext(DbContextOptions<AirportDatabaseContext> options) : base(options)
    {

    }
}
