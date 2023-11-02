using Application.Commands.FlightDestinations;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.FlightDestinations;

public class DeleteFlightDestinationHandler : IRequestHandler<DeleteFlightDestinationCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteFlightDestinationHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task Handle(DeleteFlightDestinationCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.FlightDestinationRepository.DeleteAsync(request.Id);
        await _unitOfWork.SaveChangesAsync();
    }
}