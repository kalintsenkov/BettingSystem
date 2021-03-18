namespace BettingSystem.Application.Teams.Commands.Edit
{
    using FluentValidation;

    using static Domain.Common.Models.ModelConstants.Common;

    public class EditTeamCommandValidator : AbstractValidator<EditTeamCommand>
    {
        public EditTeamCommandValidator()
            => this.RuleFor(t => t.Name)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();
    }
}
