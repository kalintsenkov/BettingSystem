namespace BettingSystem.Application.Features.Bets.Commands.Create
{
    using Domain.Common;
    using Domain.Models.Bets;
    using FluentValidation;

    using static Domain.Models.ModelConstants.Bet;

    public class CreateBetCommandValidator : AbstractValidator<CreateBetCommand>
    {
        public CreateBetCommandValidator()
        {
            this.RuleFor(b => b.Amount)
                .InclusiveBetween(MinAmountValue, MaxAmountValue);

            this.RuleFor(b => b.Prediction)
                .Must(Enumeration.HasValue<Prediction>)
                .WithMessage("'{PropertyName}' is not valid");
        }
    }
}
