using Application.DTO.Response;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public class AircraftResolver : IValueResolver<FlightDestination, FlightDestinationResponse, FlightDestinationAircraft>
{
    
    //To avoid circular reference in DTOs
    public FlightDestinationAircraft Resolve(FlightDestination source, FlightDestinationResponse destination,
        FlightDestinationAircraft destMember, ResolutionContext context)
    {
        if (null == source.Aircraft)
        {
            return null;  
        }
        
        return new FlightDestinationAircraft
        {
            Id = source.Aircraft.Id,
            FlightHours =source.Aircraft.FlightHours,
            Manufacturer = source.Aircraft.Manufacturer,
            Model = source.Aircraft.Model,
            Year = source.Aircraft.Year
        };
    }
}