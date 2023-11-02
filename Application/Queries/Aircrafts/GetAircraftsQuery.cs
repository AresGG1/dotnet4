using Application.DTO.Response;
using MediatR;

namespace Application.Queries.Aircrafts;

public class GetAircraftsQuery : IRequest<IEnumerable<AircraftResponse>>
{
    
}