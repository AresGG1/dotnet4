using Application.DTO.Response;
using Application.Queries.FlightDestinations;
using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models;
using MediatR;

namespace Application.Handlers.FlightDestinations;

public class GetFlightDestinationByIdHandler : IRequestHandler<GetFlightDestinationByIdQuery, FlightDestinationResponse>
{
    private readonly IFlightDestinationRepository _flightDestinationRepository;
    private readonly IMapper _mapper;

    public GetFlightDestinationByIdHandler(IFlightDestinationRepository flightDestinationRepository, IMapper mapper)
    {
        _flightDestinationRepository = flightDestinationRepository;
        _mapper = mapper;
    }
    
    public async Task<FlightDestinationResponse> Handle(GetFlightDestinationByIdQuery request, CancellationToken cancellationToken)
    {
        var flightDestination = await _flightDestinationRepository.GetCompleteEntityAsync(request.Id);
        
        return _mapper.Map<FlightDestination, FlightDestinationResponse>(flightDestination);
    }
}