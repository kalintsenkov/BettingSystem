namespace BettingSystem.Domain.Models.Matches
{
    using System;
    using Common;
    using Teams;

    public class Match : Entity<int>, IAggregateRoot
    {
        internal Match(
            DateTime startDate,
            Team homeTeam,
            Team awayTeam,
            Stadium stadium,
            Statistics statistics)
        {
            this.StartDate = startDate;
            this.HomeTeam = homeTeam;
            this.AwayTeam = awayTeam;
            this.Stadium = stadium;
            this.Statistics = statistics;
        }

        private Match(DateTime startDate)
        {
            this.StartDate = startDate;

            this.HomeTeam = default!;
            this.AwayTeam = default!;
            this.Stadium = default!;
            this.Statistics = default!;
        }

        public DateTime StartDate { get; private set; }

        public Team HomeTeam { get; private set; }

        public Team AwayTeam { get; private set; }

        public Stadium Stadium { get; private set; }

        public Statistics Statistics { get; private set; }

        public Result GetResult() => (this.Statistics.HomeScore, this.Statistics.AwayScore) switch
        {
            var (homeScore, awayScore) when !homeScore.HasValue && !awayScore.HasValue => Result.NotFinished,
            var (homeScore, awayScore) when homeScore > awayScore => Result.Home,
            var (homeScore, awayScore) when homeScore < awayScore => Result.Away,
            var (homeScore, awayScore) when homeScore == awayScore => Result.Draw,
            (_, _) => Result.NotFinished
        };

        public Match UpdateStartDate(DateTime startDate)
        {
            this.StartDate = startDate;

            return this;
        }

        public Match UpdateHomeTeam(Team homeTeam)
        {
            this.HomeTeam = homeTeam;

            return this;
        }

        public Match UpdateAwayTeam(Team awayTeam)
        {
            this.AwayTeam = awayTeam;

            return this;
        }

        public Match UpdateStadium(Stadium stadium)
        {
            this.Stadium = stadium;

            return this;
        }

        public Match UpdateStatistics(int? homeScore, int? awayScore)
        {
            this.Statistics = new Statistics(homeScore, awayScore);

            return this;
        }
    }
}
