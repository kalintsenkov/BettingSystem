namespace BettingSystem.Application.Championships.Groups.Commands.Common
{
    using Application.Common;
    using FluentValidation;

    using static Domain.Common.Models.ModelConstants.Common;

    public class GroupCommandValidator<TCommand> : AbstractValidator<GroupCommand<TCommand>>
        where TCommand : EntityCommand<int>
    {
        public GroupCommandValidator()
            => this.RuleFor(m => m.Name)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();
    }
}
