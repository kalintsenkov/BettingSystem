namespace BettingSystem.Domain.Betting.Models.Matches
{
    using System;
    using System.Collections.Generic;
    using Common;

    internal class MatchData : IInitialData
    {
        public Type EntityType => typeof(Match);

        public IEnumerable<object> GetData()
            => new List<Match>
            {
                new Match(
                    DateTime.Today.AddHours(5),
                    new Team("Man United"),
                    new Team("Man City"),
                    new Statistics(null, null),
                    Status.NotStarted),

                new Match(
                    DateTime.Today.AddDays(2),
                    new Team("Barcelona"),
                    new Team("Real Madrid"),
                    new Statistics(0, 3),
                    Status.FirstHalf)
            };
    }
}
