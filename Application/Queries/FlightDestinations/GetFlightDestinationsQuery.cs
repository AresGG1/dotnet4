using Application.DTO.Response;
using MediatR;

namespace Application.Queries.FlightDestinations;

public class GetFlightDestinationsQuery : IRequest<IEnumerable<FlightDestinationResponse>>
{
    
}