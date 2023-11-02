using Domain.Interfaces.Repositories;

namespace Domain.Interfaces;

public interface IUnitOfWork
{
    public IAircraftRepository AircraftRepository { get; }
    public IFlightDestinationRepository FlightDestinationRepository { get; }
    public Task SaveChangesAsync();
}
