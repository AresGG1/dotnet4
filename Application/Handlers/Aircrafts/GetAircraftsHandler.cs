using Application.DTO.Response;
using Application.Queries.Aircrafts;
using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models;
using MediatR;

namespace Application.Handlers.Aircrafts;

public class GetAircraftsHandler : IRequestHandler<GetAircraftsQuery, IEnumerable<AircraftResponse>>
{
    private readonly IAircraftRepository _aircraftRepository;
    private readonly IMapper _mapper;

    public GetAircraftsHandler(IAircraftRepository aircraftRepository, IMapper mapper)
    {
        _aircraftRepository = aircraftRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<AircraftResponse>> Handle(GetAircraftsQuery request, CancellationToken cancellationToken)
    {
        var aircrafts = await _aircraftRepository.GetAsync();

        return aircrafts.Select(_mapper.Map<Aircraft, AircraftResponse>);
    }
}