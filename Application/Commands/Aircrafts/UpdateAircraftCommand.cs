using Application.DTO.Response;
using MediatR;

namespace Application.Commands.Aircrafts;

public class UpdateAircraftCommand : IRequest<AircraftResponse>, IRequest
{
    public int Id { get; set; }
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public int FlightHours { get; set; }
}
