using Application.DTO.Response;
using MediatR;

namespace Application.Commands.FlightDestinations;

public class CreateFlightDestinationCommand : IRequest<FlightDestinationResponse>
{
    public DateTime Start { get; set; }
    public int AircraftId { get; set; }
    public decimal TicketPrice { get; set; }
}
