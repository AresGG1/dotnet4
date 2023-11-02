using Application.Commands.Aircrafts;
using Application.DTO.Response;
using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Models;
using MediatR;

namespace Application.Handlers.Aircrafts;

public class CreateAircraftHandler : IRequestHandler<CreateAircraftCommand, AircraftResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAircraftHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<AircraftResponse> Handle(CreateAircraftCommand request, CancellationToken cancellationToken)
    {
        var res = await _unitOfWork.AircraftRepository.InsertAsync(_mapper.Map<Aircraft>(request));
        await _unitOfWork.SaveChangesAsync();
        
        return _mapper.Map<Aircraft, AircraftResponse>(res);
    }
}