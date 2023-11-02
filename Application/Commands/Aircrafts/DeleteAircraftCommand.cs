using MediatR;

namespace Application.Commands.Aircrafts;

public class DeleteAircraftCommand : IRequest
{
    public DeleteAircraftCommand(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}
