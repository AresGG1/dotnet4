using System.Data;
using Application.Commands.FlightDestinations;
using FluentValidation;

namespace Application.Validation.FlightDestination;

public class CreateFlightDestinationCommandValidator : AbstractValidator<CreateFlightDestinationCommand>
{
    public CreateFlightDestinationCommandValidator()
    {
        RuleFor(fd => fd.Start)
            .NotEmpty();

        RuleFor(fd => fd.TicketPrice)
            .NotEmpty();
        
        RuleFor(fd => fd.AircraftId)
            .NotEmpty();
    }
}