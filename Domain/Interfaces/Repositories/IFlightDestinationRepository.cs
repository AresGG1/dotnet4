using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IFlightDestinationRepository : IRepository<FlightDestination>
{
    Task<IEnumerable<FlightDestination>> GetByAircraftIdAsync(int aircraftId);
}
