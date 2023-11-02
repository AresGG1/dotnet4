using Application.Commands.Aircrafts;
using Application.Commands.FlightDestinations;
using Application.DTO.Response;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateAircraftMap();
        CreateFlightDestinationMap();
    }
    
    private void CreateAircraftMap()
    {
        //Response
        CreateMap<Aircraft, AircraftResponse>()
            .ForMember(dest => dest.FlightDestinations, 
                opt => opt.MapFrom<FlightDestinationResolver>());
        
        //Request
        CreateMap<CreateAircraftCommand, Aircraft>();
        CreateMap<UpdateAircraftCommand, Aircraft>();

    }

    private void CreateFlightDestinationMap()
    {
        //Response
        CreateMap<FlightDestination, FlightDestinationResponse>()
            .ForMember(dest => dest.Aircraft,
                opt => opt.MapFrom<AircraftResolver>());
        
        //Request
        CreateMap<CreateFlightDestinationCommand, FlightDestination>();
        CreateMap<UpdateFlightDestinationCommand, FlightDestination>();
        
    }
}