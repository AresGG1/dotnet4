using Domain.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class AircraftRepository : GenericRepository<Aircraft>, IAircraftRepository
{
    public AircraftRepository(AirportDatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public override async Task<IEnumerable<Aircraft>> GetAsync()
    {
        return await Table
            .Include(a => a.FlightDestinations)
            .ToListAsync();
    }

    public override async Task<Aircraft> GetCompleteEntityAsync(int id)
    {
        var aircraft = await Table
            .Include(a => a.FlightDestinations) // Include the FlightDestination
            .FirstOrDefaultAsync(a => a.Id == id);

        if (aircraft == null)
        {
            throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
        }
        
        return aircraft;
    }


}
