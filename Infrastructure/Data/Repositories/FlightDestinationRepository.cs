using Domain.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class FlightDestinationRepository : GenericRepository<FlightDestination>, IFlightDestinationRepository
{
    public FlightDestinationRepository(AirportDatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public override async Task<FlightDestination> GetCompleteEntityAsync(int id)
    {
        var flightDestination = await Table
            .Include(fd => fd.Aircraft)
            .FirstOrDefaultAsync(fd => fd.Id == id);

        if (null == flightDestination)
        {
            throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
        }
        
        Console.WriteLine(flightDestination.Aircraft.Manufacturer);
        
        return flightDestination;
    }

    public override async Task<IEnumerable<FlightDestination>> GetAsync()
    {
        return await Table
            .Include(a => a.Aircraft)
            .ToListAsync();
    }
}