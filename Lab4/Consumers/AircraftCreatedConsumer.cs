using Application.Commands.Aircrafts;
using Application.Handlers.Aircrafts;
using MassTransit;
using MediatR;
using Shared;

namespace Lab4.Consumers;

public class AircraftCreatedConsumer : IConsumer<AircraftCreated>
{
    private readonly IMediator _mediator;
    private readonly CreateAircraftHandler _aircraftHandler;

    public AircraftCreatedConsumer(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task Consume(ConsumeContext<AircraftCreated> context)
    {
        var message = context.Message;
        await _mediator.Send(new CreateAircraftCommand
        {
            Model = message.Model,
            Manufacturer = message.Manufacturer,
            Year = message.Year,
            FlightHours = message.FlightHours,
        });
        
        Console.WriteLine($"Aircraft created");
    }
}
