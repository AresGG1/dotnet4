using Application.Commands.FlightDestinations;
using FluentValidation;

namespace Application.Validation.FlightDestination;

public class DeleteFlightDestinationCommandValidator : AbstractValidator<DeleteFlightDestinationCommand>
{
    public DeleteFlightDestinationCommandValidator()
    {
        RuleFor(fd => fd.Id)
            .NotEmpty();
    }   
}
