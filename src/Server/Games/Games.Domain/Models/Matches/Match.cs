namespace BettingSystem.Domain.Games.Models.Matches
{
    using System;
    using Common;
    using Common.Events.Matches;
    using Common.Models;
    using Exceptions;
    using Teams;

    using static Common.Models.ModelConstants.Common;

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

            this.RaiseEvent(new MatchCreatedEvent(this.StartDate));
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

        public DateTime StartDate { get; private set; }

        public Team HomeTeam { get; private set; }

        public Team AwayTeam { get; private set; }

        public Stadium Stadium { get; private set; }

        public Statistics Statistics { get; private set; }

        public Status Status { get; private set; }

        public Match UpdateStartDate(DateTime startDate)
        {
            this.Validate(startDate);

            this.StartDate = startDate;

            this.RaiseEvent(new MatchStartDateUpdatedEvent(
                this.Id,
                this.StartDate));

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

        public Match UpdateStatistics(int homeScore, int awayScore)
        {
            this.Statistics
                .UpdateHomeScore(homeScore)
                .UpdateAwayScore(awayScore);

            this.RaiseEvent(new MatchStatisticsUpdatedEvent(
                this.Id,
                this.Statistics.HomeScore,
                this.Statistics.AwayScore,
                this.Statistics.HalfTimeHomeScore,
                this.Statistics.HalfTimeAwayScore));

            return this;
        }

        public Match StartFirstHalf()
        {
            this.UpdateStatistics(Zero, Zero);

            this.Status = Status.FirstHalf;

            this.RaiseEvent(new MatchStatusUpdatedEvent(
                this.Id,
                this.Status.Value));

            this.RaiseEvent(new MatchStatisticsUpdatedEvent(
                this.Id,
                this.Statistics.HomeScore,
                this.Statistics.AwayScore,
                this.Statistics.HalfTimeHomeScore,
                this.Statistics.HalfTimeAwayScore));

            return this;
        }

        public Match HalfTime()
        {
            this.ValidateIfMatchIsStarted();

            this.Statistics.UpdateHalfTimeScore();

            this.Status = Status.HalfTime;

            this.RaiseEvent(new MatchStatusUpdatedEvent(
                this.Id,
                this.Status.Value));

            this.RaiseEvent(new MatchStatisticsUpdatedEvent(
                this.Id,
                this.Statistics.HomeScore,
                this.Statistics.AwayScore,
                this.Statistics.HalfTimeHomeScore,
                this.Statistics.HalfTimeAwayScore));

            return this;
        }

        public Match StartSecondHalf()
        {
            this.ValidateIfMatchIsStarted();

            this.Status = Status.SecondHalf;

            this.RaiseEvent(new MatchStatusUpdatedEvent(
                this.Id,
                this.Status.Value));

            return this;
        }

        public Match Finish()
        {
            this.ValidateIfMatchIsStarted();

            this.Status = Status.Finished;

            this.RaiseEvent(new MatchStatusUpdatedEvent(
                this.Id,
                this.Status.Value));

            if (this.Statistics.HomeScore.HasValue &&
                this.Statistics.AwayScore.HasValue)
            {
                this.RaiseEvent(new MatchFinishedEvent(
                    this.HomeTeam.Id,
                    this.AwayTeam.Id,
                    this.Statistics.HomeScore.Value,
                    this.Statistics.AwayScore.Value));
            }

            return this;
        }

        public Match Cancel()
        {
            this.Status = Status.Cancelled;

            this.RaiseEvent(new MatchStatusUpdatedEvent(
                this.Id,
                this.Status.Value));

            return this;
        }

        private void Validate(DateTime startDate)
        {
            if (startDate < DateTime.Today)
            {
                throw new InvalidMatchException();
            }
        }

        private void ValidateIfMatchIsStarted()
        {
            if (this.Status == Status.NotStarted)
            {
                throw new InvalidMatchException("This match is not started yet.");
            }
        }
    }
}
