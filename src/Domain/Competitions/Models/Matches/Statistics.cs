namespace BettingSystem.Domain.Competitions.Models.Matches
{
    using Common.Models;
    using Exceptions;

    using static Common.Models.ModelConstants.Common;

    public class Statistics : ValueObject
    {
        internal Statistics(int? homeScore, int? awayScore)
        {
            this.Validate(homeScore, awayScore);

            this.HomeScore = homeScore;
            this.AwayScore = awayScore;
        }

        public int? HomeScore { get; private set; }

        public int? AwayScore { get; private set; }

        public int? HalfTimeHomeScore { get; private set; }

        public int? HalfTimeAwayScore { get; private set; }

        internal Statistics UpdateHomeScore(int homeScore)
        {
            this.ValidateHomeScore(homeScore);

            this.HomeScore = homeScore;

            return this;
        }

        internal Statistics UpdateAwayScore(int awayScore)
        {
            this.ValidateAwayScore(awayScore);

            this.AwayScore = awayScore;

            return this;
        }

        internal void UpdateHalfTimeScore()
        {
            this.HalfTimeHomeScore = this.HomeScore;
            this.HalfTimeAwayScore = this.AwayScore;
        }

        private void Validate(int? homeScore, int? awayScore)
        {
            this.ValidateHomeScore(homeScore);
            this.ValidateAwayScore(awayScore);
        }

        private void ValidateHomeScore(int? homeScore)
            => Guard.AgainstOutOfRange<InvalidMatchException>(
                homeScore,
                Zero,
                int.MaxValue,
                nameof(this.HomeScore));

        private void ValidateAwayScore(int? awayScore)
            => Guard.AgainstOutOfRange<InvalidMatchException>(
                awayScore,
                Zero,
                int.MaxValue,
                nameof(this.AwayScore));
    }
}
