namespace BettingSystem.Application.Championships.Tournaments.Commands.Create
{
    using FluentValidation;

    using static Domain.Common.Models.ModelConstants.Common;

    public class CreateTournamentCommandValidator : AbstractValidator<CreateTournamentCommand>
    {
        public CreateTournamentCommandValidator()
            => this.RuleFor(m => m.Name)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();
    }
}
