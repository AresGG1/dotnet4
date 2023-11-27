using Application.DTO.Response;
using MediatR;

namespace Application.Queries.FlightDestinations;

public class GetFlightDestinationsByAircraftIdQuery : IRequest<IEnumerable<FlightDestinationResponse>>
{
    public int AircraftId { get; set; }
}
