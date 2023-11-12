using Application.Commands.FlightDestinations;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.FlightDestinations;

public class UpdateFlightDestinationHandler : IRequestHandler<UpdateFlightDestinationCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateFlightDestinationHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task Handle(UpdateFlightDestinationCommand request, CancellationToken cancellationToken)
    {
        var flightDestination = _mapper.Map<FlightDestination>(request);
        var currentFlightDest =
            await _unitOfWork.FlightDestinationRepository.GetCompleteEntityAsync(flightDestination.Id);

        if (flightDestination.AircraftId != currentFlightDest.AircraftId)
        {
            var newAircraft = await _unitOfWork.AircraftRepository.GetCompleteEntityAsync(flightDestination.AircraftId);
            newAircraft.AddFlightDestination(flightDestination);
            currentFlightDest.Aircraft.RemoveFlightDestination(currentFlightDest);
        }

        
        await _unitOfWork.FlightDestinationRepository.UpdateAsync(flightDestination, currentFlightDest);
        
        await _unitOfWork.SaveChangesAsync();
        
    }
}
