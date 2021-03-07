namespace BettingSystem.Domain.Betting.Models.Matches
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
            Statistics statistics,
            Status status)
        {
            this.Validate(startDate);

            this.StartDate = startDate;
            this.HomeTeam = homeTeam;
            this.AwayTeam = awayTeam;
            this.Statistics = statistics;
            this.Status = status;
        }

        private Match(DateTime startDate)
        {
            this.StartDate = startDate;

            this.HomeTeam = default!;
            this.AwayTeam = default!;
            this.Statistics = default!;
            this.Status = default!;
        }

        public DateTime StartDate { get; }

        public Team HomeTeam { get; }

        public Team AwayTeam { get; }

        public Statistics Statistics { get; }

        public Status Status { get; private set; }

        // For testing purposes
        internal void Finish() => this.Status = Status.Finished;

        private void Validate(DateTime startDate)
        {
            if (startDate < DateTime.Today)
            {
                throw new InvalidMatchException();
            }
        }
    }
}
