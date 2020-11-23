namespace BettingSystem.Domain.Models.Matches
{
    using Common;
    using Exceptions;

    using static ModelConstants.Common;

    public class Statistics : ValueObject
    {
        internal Statistics(int? homeScore, int? awayScore, Status status)
        {
            this.Validate(homeScore, awayScore);

            this.HomeScore = homeScore;
            this.AwayScore = awayScore;
            this.Status = status;
        }

        private Statistics(int? homeScore, int? awayScore)
        {
            this.HomeScore = homeScore;
            this.AwayScore = awayScore;

            this.Status = default!;
        }

        public int? HomeScore { get; private set; }

        public int? AwayScore { get; private set; }

        public Status Status { get; private set; }

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
