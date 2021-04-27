namespace BettingSystem.Domain.Betting.Factories.Matches
{
    using System;
    using Models.Matches;

    internal class MatchFactory : IMatchFactory
    {
        private readonly Status defaultMatchStatus = Status.NotStarted;
        private readonly Statistics defaultMatchStatistics = new(homeScore: null, awayScore: null);

        private DateTime matchStartDate = default!;

        public IMatchFactory WithStartDate(DateTime startDate)
        {
            this.matchStartDate = startDate;
            return this;
        }

        public Match Build() => new Match(
            this.matchStartDate,
            this.defaultMatchStatistics,
            this.defaultMatchStatus);
    }
}
