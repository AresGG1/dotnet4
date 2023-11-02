using Application.Commands.Aircrafts;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Handlers.Aircrafts;

public class DeleteAircraftHandler : IRequestHandler<DeleteAircraftCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAircraftHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task Handle(DeleteAircraftCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.AircraftRepository.DeleteAsync(request.Id);
        
        await _unitOfWork.SaveChangesAsync();
    }
}
