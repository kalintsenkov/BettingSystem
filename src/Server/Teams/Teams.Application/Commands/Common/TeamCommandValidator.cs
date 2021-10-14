namespace BettingSystem.Application.Teams.Commands.Common
{
    using Application.Common;
    using FluentValidation;

    using static Domain.Common.Models.ModelConstants.Common;

    public class TeamCommandValidator<TCommand> : AbstractValidator<TeamCommand<TCommand>>
        where TCommand : EntityCommand<int>
    {
        public TeamCommandValidator()
        {
            this.RuleFor(m => m.Name)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            this.RuleFor(m => m.Logo)
                .NotNull()
                .NotEmpty();

            this.RuleFor(m => m.Coach)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();
        }
    }
}
