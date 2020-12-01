namespace BettingSystem.Application.Betting.Gamblers.Commands.Create
{
    using FluentValidation;

    using static Domain.Common.Models.ModelConstants.Common;

    public class CreateGamblerCommandValidator : AbstractValidator<CreateGamblerCommand>
    {
        public CreateGamblerCommandValidator()
            => this.RuleFor(u => u.Name)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();
    }
}
