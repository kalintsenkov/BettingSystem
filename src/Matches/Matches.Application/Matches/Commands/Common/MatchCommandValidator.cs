namespace BettingSystem.Application.Matches.Matches.Commands.Common
{
    using System;
    using Application.Common;
    using FluentValidation;
    using static Domain.Common.Models.ModelConstants.Common;

    public class MatchCommandValidator<TCommand> : AbstractValidator<MatchCommand<TCommand>>
        where TCommand : EntityCommand<int>
    {
        public MatchCommandValidator()
        {
            this.RuleFor(m => m.StartDate)
                .GreaterThanOrEqualTo(DateTime.Today);

            this.RuleFor(m => m.HomeTeam)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            this.RuleFor(m => m.AwayTeam)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            this.RuleFor(m => m.StadiumName)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            this.RuleFor(m => m.StadiumImage)
                .NotEmpty();
        }
    }
}
