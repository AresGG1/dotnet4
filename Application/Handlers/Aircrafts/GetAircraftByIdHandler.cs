using Application.DTO.Response;
using Application.Queries.Aircrafts;
using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models;
using MediatR;

namespace Application.Handlers.Aircrafts;

public class GetAircraftByIdHandler : IRequestHandler<GetAircraftByIdQuery, AircraftResponse>
{
    private readonly IAircraftRepository _aircraftRepository;
    private readonly IMapper _mapper;

    public GetAircraftByIdHandler(IAircraftRepository aircraftRepository, IMapper mapper)
    {
        _aircraftRepository = aircraftRepository;
        _mapper = mapper;
    }
    
    public async Task<AircraftResponse> Handle(GetAircraftByIdQuery request, CancellationToken cancellationToken)
    {
        var aircraft = await _aircraftRepository.GetCompleteEntityAsync(request.Id);

        return _mapper.Map<Aircraft, AircraftResponse>(aircraft);
    }
}