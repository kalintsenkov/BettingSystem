namespace BettingSystem.Application.Teams.Commands.AddPlayer;

using Domain.Common.Models;
using Domain.Teams.Models;
using FluentValidation;

using static Domain.Common.Models.ModelConstants.Common;

public class AddPlayerCommandValidator : AbstractValidator<AddPlayerCommand>
{
    public AddPlayerCommandValidator()
    {
        this.RuleFor(t => t.Name)
            .MinimumLength(MinNameLength)
            .MaximumLength(MaxNameLength)
            .NotEmpty();

        this.RuleFor(p => p.Position)
            .Must(Enumeration.HasValue<Position>)
            .WithMessage("'{PropertyName}' is not valid");
    }
}