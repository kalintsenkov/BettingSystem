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
            Prediction prediction,
            bool isProfitable)
        {
            this.Validate(match, amount);

            this.Match = match;
            this.Amount = amount;
            this.Prediction = prediction;
            this.IsProfitable = isProfitable;
        }

        private Bet(decimal amount, bool isProfitable)
        {
            this.Amount = amount;
            this.IsProfitable = isProfitable;

            this.Match = default!;
            this.Prediction = default!;
        }

        public Match Match { get; private set; }

        public decimal Amount { get; private set; }

        public Prediction Prediction { get; private set; }

        public bool IsProfitable { get; private set; }

        public Bet UpdateMatch(Match match)
        {
            this.Match = match;

            return this;
        }

        public Bet UpdateAmount(decimal amount)
        {
            this.ValidateAmount(amount);

            this.Amount = amount;

            return this;
        }

        public Bet MakeProfitable()
        {
            this.IsProfitable = true;

            return this;
        }

        private void Validate(Match match, decimal amount)
        {
            this.ValidateMatch(match);
            this.ValidateAmount(amount);
        }

        private void ValidateAmount(decimal amount)
            => Guard.AgainstOutOfRange<InvalidBetException>(
                amount,
                Zero,
                decimal.MaxValue,
                nameof(this.Amount));

        private void ValidateMatch(Match match)
        {
            var matchStatus = match.Status;

            if (matchStatus == Status.Finished)
            {
                throw new InvalidBetException("You cannot make bets on finished match.");
            }

            if (matchStatus == Status.Cancelled)
            {
                throw new InvalidBetException("You cannot make bets on cancelled match.");
            }
        }
    }
}
