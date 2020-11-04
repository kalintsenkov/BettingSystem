namespace BettingSystem.Domain.Models.Matches
{
    using Common;
    using Exceptions;

    using static ModelConstants.Common;

    public class Statistics : ValueObject
    {
        public Statistics(int? homeScore, int? awayScore)
        {
            this.Validate(homeScore, awayScore);

            this.HomeScore = homeScore;
            this.AwayScore = awayScore;
        }

        public int? HomeScore { get; private set; }

        public int? AwayScore { get; private set; }

        private void Validate(int? homeScore, int? awayScore)
        {
            Guard.AgainstOutOfRange<InvalidMatchException>(
                homeScore,
                Zero,
                int.MaxValue,
                nameof(this.HomeScore));

            Guard.AgainstOutOfRange<InvalidMatchException>(
                awayScore,
                Zero,
                int.MaxValue,
                nameof(this.AwayScore));
        }
    }
}
