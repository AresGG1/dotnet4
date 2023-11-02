using Application.Commands.Aircrafts;
using FluentValidation;

namespace Application.Validation.Aircraft;

public class UpdateAircraftCommandValidator : AbstractValidator<UpdateAircraftCommand>
{
    public UpdateAircraftCommandValidator()
    {
        RuleFor(a => a.Id)
            .NotEmpty();
        
        RuleFor(a => a.Manufacturer)
            .NotEmpty()
            .MaximumLength(25);
        
        RuleFor(a => a.Model)
            .NotEmpty()
            .MaximumLength(30);

        RuleFor(a => a.Year)
            .NotEmpty()
            .InclusiveBetween(1965, DateTime.Now.Year);
    }
}
