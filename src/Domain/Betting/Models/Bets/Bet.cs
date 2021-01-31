namespace BettingSystem.Domain.Betting.Models.Bets
{
    using Common;
    using Common.Models;
    using Exceptions;
    using Matches;

    using static ModelConstants.Bet;

    public class Bet : Entity<int>, IAggregateRoot
    {
        internal Bet(
            Match match,
            decimal amount,
            Prediction prediction,
            bool isProfitable)
        {
            this.Validate(amount);

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
            this.Validate(amount);

            this.Amount = amount;

            return this;
        }

        public Bet MakeProfitable()
        {
            this.ValidateIfMatchIsFinished(this.Match);

            var homeScore = this.Match.Statistics.HomeScore;
            var awayScore = this.Match.Statistics.AwayScore;

            if (homeScore > awayScore && this.Prediction == Prediction.Home)
            {
                this.IsProfitable = true;
            }
            else if (homeScore < awayScore && this.Prediction == Prediction.Away)
            {
                this.IsProfitable = true;
            }
            else if (homeScore == awayScore && this.Prediction == Prediction.Draw)
            {
                this.IsProfitable = true;
            }
            else
            {
                throw new InvalidBetException("Wrong bet prediction.");
            }

            return this;
        }

        private void ValidateIfMatchIsFinished(Match match)
        {
            if (match.Status != Status.Finished)
            {
                throw new InvalidBetException("This match is not finished yet.");
            }
        }

        private void Validate(decimal amount)
            => Guard.AgainstOutOfRange<InvalidBetException>(
                amount,
                MinAmountValue,
                MaxAmountValue,
                nameof(this.Amount));
    }
}
