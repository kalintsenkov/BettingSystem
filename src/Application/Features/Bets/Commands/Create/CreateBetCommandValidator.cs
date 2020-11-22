namespace BettingSystem.Application.Features.Bets.Commands.Create
{
    using Domain.Common;
    using Domain.Models.Bets;
    using FluentValidation;

    using static Domain.Models.ModelConstants.Common;

    public class CreateBetCommandValidator : AbstractValidator<CreateBetCommand>
    {
        public CreateBetCommandValidator()
        {
            this.RuleFor(b => b.Amount)
                .InclusiveBetween(Zero, decimal.MaxValue);

            this.RuleFor(b => b.Prediction)
                .Must(Enumeration.HasValue<Prediction>)
                .WithMessage("'{PropertyName}' is not valid");
        }
    }
}
