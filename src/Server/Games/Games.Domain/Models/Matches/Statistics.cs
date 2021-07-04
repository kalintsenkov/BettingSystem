namespace BettingSystem.Domain.Games.Models.Matches
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
            this.ValidateScore(homeScore, nameof(this.HomeScore));

            this.HomeScore = homeScore;

            return this;
        }

        internal Statistics UpdateAwayScore(int awayScore)
        {
            this.ValidateScore(awayScore, nameof(this.AwayScore));

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
            this.ValidateScore(homeScore, nameof(this.HomeScore));
            this.ValidateScore(awayScore, nameof(this.AwayScore));
        }

        private void ValidateScore(int? score, string name)
            => Guard.AgainstOutOfRange<InvalidMatchException>(
                score,
                Zero,
                int.MaxValue,
                name);
    }
}
