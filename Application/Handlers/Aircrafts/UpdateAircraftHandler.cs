using Application.Commands.Aircrafts;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Aircrafts;

public class UpdateAircraftHandler : IRequestHandler<UpdateAircraftCommand>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAircraftHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }


    public async Task Handle(UpdateAircraftCommand request, CancellationToken cancellationToken)
    {
        var aircraft = _mapper.Map<Aircraft>(request);
        await _unitOfWork.AircraftRepository.UpdateAsync(aircraft);

        try
        {
            await _unitOfWork.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            //Throw not found exception
            await _unitOfWork.AircraftRepository.GetByIdAsync(aircraft.Id);
            
            throw;
        }
    }
}
