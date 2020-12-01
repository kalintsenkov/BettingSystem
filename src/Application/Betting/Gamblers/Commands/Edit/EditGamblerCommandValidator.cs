namespace BettingSystem.Application.Betting.Gamblers.Commands.Edit
{
    using FluentValidation;
    using static Domain.Common.Models.ModelConstants.Common;

    public class EditGamblerCommandValidator : AbstractValidator<EditGamblerCommand>
    {
        public EditGamblerCommandValidator()
            => this.RuleFor(g => g.Name)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();
    }
}
