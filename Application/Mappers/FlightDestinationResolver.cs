using Application.DTO.Response;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public class FlightDestinationResolver : IValueResolver<Aircraft,AircraftResponse,List<AircraftFlightDestination>>
{

    //To avoid circular reference in DTOs
    public List<AircraftFlightDestination> Resolve(
        Aircraft source,
        AircraftResponse destination,
        List<AircraftFlightDestination> destMember,
        ResolutionContext context)
    {
        List<AircraftFlightDestination> flightDestinations = new List<AircraftFlightDestination>();

        if (null == source.FlightDestinations)
        {
            return flightDestinations;  
        }
        
        
        foreach (var elem in source.FlightDestinations)
        {
            flightDestinations.Add(new AircraftFlightDestination
            {
                Id = elem.Id,
                Start = elem.Start,
                TicketPrice = elem.TicketPrice
            });
        }

        return flightDestinations;
    }
}