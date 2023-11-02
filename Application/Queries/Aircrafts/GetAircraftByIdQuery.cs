using Application.DTO.Response;
using MediatR;

namespace Application.Queries.Aircrafts;

public class GetAircraftByIdQuery : IRequest<AircraftResponse>
{
    public int Id { get; }
    
    public GetAircraftByIdQuery(int id)
    {
        Id = id;
    }
}