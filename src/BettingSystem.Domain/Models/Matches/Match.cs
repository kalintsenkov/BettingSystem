namespace BettingSystem.Domain.Models.Matches
{
    using System;
    using Common;
    using Exceptions;
    using Teams;

    public class Match : Entity<int>, IAggregateRoot
    {
        public Match(
            DateTime startDate,
            Team homeTeam,
            Team awayTeam,
            Stadium stadium,
            Statistics statistics)
        {
            this.Validate(startDate);

            this.StartDate = startDate;
            this.HomeTeam = homeTeam;
            this.AwayTeam = awayTeam;
            this.Statistics = statistics;
            this.Stadium = stadium;
        }

        private Match(DateTime startDate)
        {
            this.StartDate = startDate;

            this.HomeTeam = default!;
            this.AwayTeam = default!;
            this.Statistics = default!;
            this.Stadium = default!;
        }

        public DateTime StartDate { get; private set; }

        public Team HomeTeam { get; private set; }

        public Team AwayTeam { get; private set; }

        public Stadium Stadium { get; private set; }

        public Statistics Statistics { get; private set; }

        public Result Result => (this.Statistics.HomeScore, this.Statistics.AwayScore) switch
        {
            var (homeScore, awayScore) when !homeScore.HasValue && !awayScore.HasValue => Result.NotFinished,
            var (homeScore, awayScore) when homeScore > awayScore => Result.Home,
            var (homeScore, awayScore) when homeScore < awayScore => Result.Away,
            var (homeScore, awayScore) when homeScore == awayScore => Result.Draw,
            (_, _) => Result.NotFinished
        };

        public Match UpdateStartDate(DateTime startDate)
        {
            this.Validate(startDate);

            this.StartDate = startDate;

            return this;
        }

        public Match UpdateHomeTeam(string homeTeam)
        {
            if (this.HomeTeam.Name != homeTeam)
            {
                this.HomeTeam = new Team(homeTeam);
            }

            return this;
        }

        public Match UpdateAwayTeam(string awayTeam)
        {
            if (this.AwayTeam.Name != awayTeam)
            {
                this.AwayTeam = new Team(awayTeam);
            }

            return this;
        }

        public Match UpdateStatistics(int? homeScore, int? awayScore)
        {
            this.Statistics = new Statistics(homeScore, awayScore);

            return this;
        }

        public Match UpdateStadium(string name, string imageUrl)
        {
            this.Stadium = new Stadium(name, imageUrl);

            return this;
        }

        private void Validate(DateTime startDate)
            => Guard.AgainstOutOfRange<InvalidMatchException>(
                startDate,
                DateTime.Today,
                DateTime.MaxValue,
                nameof(this.StartDate));
    }
}
