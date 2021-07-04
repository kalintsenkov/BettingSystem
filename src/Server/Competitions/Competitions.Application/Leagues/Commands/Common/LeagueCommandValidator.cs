namespace BettingSystem.Application.Competitions.Leagues.Commands.Common
{
    using Application.Common;
    using FluentValidation;

    using static Domain.Common.Models.ModelConstants.Common;

    public class LeagueCommandValidator<TCommand> : AbstractValidator<LeagueCommand<TCommand>>
        where TCommand : EntityCommand<int>
    {
        public LeagueCommandValidator()
            => this.RuleFor(m => m.Name)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();
    }
}
