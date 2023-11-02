using Application.DTO.Response;
using Application.Queries.FlightDestinations;
using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models;
using MediatR;

namespace Application.Handlers.FlightDestinations;

public class GetFlightDestinationsHandler : IRequestHandler<GetFlightDestinationsQuery, IEnumerable<FlightDestinationResponse>>
{
    private readonly IFlightDestinationRepository _flightDestinationRepository;
    private readonly IMapper _mapper;

    public GetFlightDestinationsHandler(IFlightDestinationRepository flightDestinationRepository, IMapper mapper)
    {
        _flightDestinationRepository = flightDestinationRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<FlightDestinationResponse>> Handle(GetFlightDestinationsQuery request, CancellationToken cancellationToken)
    {
        var flightDestinations = await _flightDestinationRepository.GetAsync();
        
        return flightDestinations.Select(_mapper.Map<FlightDestination, FlightDestinationResponse>);
    }
}