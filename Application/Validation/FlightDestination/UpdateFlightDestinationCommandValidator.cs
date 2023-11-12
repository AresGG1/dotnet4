using Application.Commands.FlightDestinations;
using FluentValidation;

namespace Application.Validation.FlightDestination;

public class UpdateFlightDestinationCommandValidator : AbstractValidator<UpdateFlightDestinationCommand>
{
     public UpdateFlightDestinationCommandValidator()
     {
          RuleFor(fd => fd.Id)
               .NotEmpty();
          RuleFor(fd => fd.Start)
               .NotEmpty();
          RuleFor(fd => fd.TicketPrice)
               .NotEmpty()
               .GreaterThanOrEqualTo(10);
          RuleFor(fd => fd.AircraftId)
               .NotEmpty();
     }
}
