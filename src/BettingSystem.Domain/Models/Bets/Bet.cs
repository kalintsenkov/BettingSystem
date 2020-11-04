namespace BettingSystem.Domain.Models.Bets
{
    using Common;
    using Exceptions;
    using Matches;

    using static ModelConstants.Common;

    public class Bet : Entity<int>, IAggregateRoot
    {
        internal Bet(
            Match match,
            decimal amount,
            Prediction prediction)
        {
            this.Validate(amount);

            this.Match = match;
            this.Amount = amount;
            this.Prediction = prediction;
        }

        private Bet(decimal amount)
        {
            this.Amount = amount;

            this.Match = default!;
            this.Prediction = default!;
        }

        public Match Match { get; private set; }

        public decimal Amount { get; private set; }

        public Prediction Prediction { get; private set; }

        public Bet UpdateMatch(Match match)
        {
            this.Match = match;

            return this;
        }

        public Bet UpdateAmount(decimal amount)
        {
            this.Validate(amount);

            this.Amount = amount;

            return this;
        }

        public Bet UpdatePrediction(Prediction prediction)
        {
            this.Prediction = prediction;

            return this;
        }

        private void Validate(decimal amount)
            => Guard.AgainstOutOfRange<InvalidBetException>(
                amount,
                Zero,
                decimal.MaxValue,
                nameof(this.Amount));
    }
}
