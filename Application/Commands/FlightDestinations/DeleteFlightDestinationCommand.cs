using MediatR;

namespace Application.Commands.FlightDestinations;

public class DeleteFlightDestinationCommand : IRequest
{
    public DeleteFlightDestinationCommand(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}
