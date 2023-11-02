using Domain;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;

namespace Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly AirportDatabaseContext _databaseContext;
    public IAircraftRepository AircraftRepository { get; }
    public IFlightDestinationRepository FlightDestinationRepository { get; }

    public UnitOfWork(
        IAircraftRepository aircraftRepository,
        IFlightDestinationRepository flightDestinationRepository,
        AirportDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
        AircraftRepository = aircraftRepository;
        FlightDestinationRepository = flightDestinationRepository;
    }
    
    public async Task SaveChangesAsync()
    {
        await _databaseContext.SaveChangesAsync();
    }
}