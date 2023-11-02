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
        
        await _unitOfWork.FlightDestinationRepository.UpdateAsync(flightDestination);
        
        try
        {
            await _unitOfWork.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            //Throw not found exception
            await _unitOfWork.FlightDestinationRepository.GetByIdAsync(flightDestination.Id);
            
            throw;
        }
    }
}
