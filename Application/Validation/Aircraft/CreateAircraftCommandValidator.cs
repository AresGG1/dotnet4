using Application.Commands.Aircrafts;
using FluentValidation;

namespace Application.Validation.Aircraft;

public class CreateAircraftCommandValidator : AbstractValidator<CreateAircraftCommand>
{
    public CreateAircraftCommandValidator()
    {
        RuleFor(a => a.Manufacturer)
            .NotEmpty()
            .MaximumLength(25);
        
        RuleFor(a => a.Model)
            .NotEmpty()
            .MaximumLength(30);

        RuleFor(a => a.Year)
            .NotEmpty()
            .InclusiveBetween(1965, DateTime.Now.Year);
        RuleFor(a => a.FlightHours)
            .NotEmpty()
            .InclusiveBetween(0, 5000);
    }
}
