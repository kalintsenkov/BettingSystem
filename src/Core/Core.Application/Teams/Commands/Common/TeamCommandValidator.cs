namespace BettingSystem.Application.Teams.Commands.Common
{
    using Application.Common;
    using FluentValidation;

    using static Domain.Common.Models.ModelConstants.Common;

    public class TeamCommandValidator<TCommand> : AbstractValidator<TeamCommand<TCommand>>
        where TCommand : EntityCommand<int>
    {
        public TeamCommandValidator()
            => this.RuleFor(t => t.Name)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();
    }
}
