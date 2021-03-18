namespace BettingSystem.Application.Competitions.Teams.Commands.Create
{
    using FluentValidation;

    using static Domain.Common.Models.ModelConstants.Common;

    public class CreateTeamCommandValidator : AbstractValidator<CreateTeamCommand>
    {
        public CreateTeamCommandValidator()
            => this.RuleFor(t => t.Name)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();
    }
}
