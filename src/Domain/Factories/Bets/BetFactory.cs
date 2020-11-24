namespace BettingSystem.Domain.Factories.Bets
{
    using Exceptions;
    using Models.Bets;
    using Models.Matches;

    internal class BetFactory : IBetFactory
    {
        private Match betMatch = default!;
        private decimal betAmount = default!;
        private Prediction betPrediction = default!;

        private bool isMatchSet = false;

        public IBetFactory WithMatch(Match match)
        {
            this.betMatch = match;
            this.isMatchSet = true;
            return this;
        }

        public IBetFactory WithAmount(decimal amount)
        {
            this.betAmount = amount;
            return this;
        }

        public IBetFactory WithPrediction(Prediction prediction)
        {
            this.betPrediction = prediction;
            return this;
        }

        public Bet Build()
        {
            if (!this.isMatchSet)
            {
                throw new InvalidBetException("Match must have a value.");
            }

            return new Bet(
                this.betMatch,
                this.betAmount,
                this.betPrediction,
                false);
        }
    }
}
