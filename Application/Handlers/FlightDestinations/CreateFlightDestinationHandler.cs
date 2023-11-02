using Application.Commands.FlightDestinations;
using Application.DTO.Response;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Handlers.FlightDestinations;

public class CreateFlightDestinationHandler : IRequestHandler<CreateFlightDestinationCommand, FlightDestinationResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateFlightDestinationHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    } 
    public async Task<FlightDestinationResponse> Handle(CreateFlightDestinationCommand request, CancellationToken cancellationToken)
    {
        var aircraft = await _unitOfWork.AircraftRepository.GetCompleteEntityAsync(request.AircraftId);
        var flightDestination = _mapper.Map<CreateFlightDestinationCommand, FlightDestination>(request);
        
        //Invoking domain logic
        aircraft.AddFlightDestination(flightDestination);
        
        await _unitOfWork.SaveChangesAsync();
        flightDestination.Aircraft = aircraft;
        
        return _mapper.Map<FlightDestination, FlightDestinationResponse>(flightDestination);
    }
}
