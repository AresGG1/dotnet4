using Application.DTO.Response;
using MediatR;

namespace Application.Queries.FlightDestinations;

public class GetFlightDestinationByIdQuery : IRequest<FlightDestinationResponse>
{
    public int Id { get; }
    
    public GetFlightDestinationByIdQuery(int id)
    {
        Id = id;
    }
}
