namespace BettingSystem.Domain.Competitions.Models.Matches
{
    using System;
    using Common;
    using Common.Models;
    using Exceptions;

    public class Match : Entity<int>, IAggregateRoot
    {
        internal Match(
            DateTime startDate,
            Team homeTeam,
            Team awayTeam,
            Stadium stadium,
            Statistics statistics,
            Status status)
        {
            this.Validate(startDate);

            this.StartDate = startDate;
            this.HomeTeam = homeTeam;
            this.AwayTeam = awayTeam;
            this.Stadium = stadium;
            this.Statistics = statistics;
            this.Status = status;
        }

        private Match(DateTime startDate)
        {
            this.StartDate = startDate;

            this.HomeTeam = default!;
            this.AwayTeam = default!;
            this.Stadium = default!;
            this.Statistics = default!;
            this.Status = default!;
        }

        public DateTime StartDate { get; }

        public Team HomeTeam { get; }

        public Team AwayTeam { get; }

        public Stadium Stadium { get; }

        public Statistics Statistics { get; }

        public Status Status { get; }

        private void Validate(DateTime startDate)
        {
            if (startDate < DateTime.Today)
            {
                throw new InvalidMatchException();
            }
        }
    }
}
