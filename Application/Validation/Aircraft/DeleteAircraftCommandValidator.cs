using Application.Commands.Aircrafts;
using FluentValidation;

namespace Application.Validation.Aircraft;

public class DeleteAircraftCommandValidator : AbstractValidator<DeleteAircraftCommand>
{
    public DeleteAircraftCommandValidator()
    {
        RuleFor(a => a.Id)
            .NotEmpty();
    }
}
