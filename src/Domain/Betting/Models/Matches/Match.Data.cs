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
                    new Stadium("Old Trafford", "https://bit.ly/3miHWzW"),
                    new Statistics(null, null),
                    Status.NotStarted),

                new Match(
                    DateTime.Today.AddDays(2),
                    new Team("Barcelona"),
                    new Team("Real Madrid"),
                    new Stadium("Camp Nou", "https://fifa.fans/2UZdIWH"),
                    new Statistics(0, 3),
                    Status.FirstHalf),

                new Match(
                    DateTime.Today.AddDays(3),
                    new Team("Chelsea"),
                    new Team("Arsenal"),
                    new Stadium("Stamford Bridge", "https://bit.ly/3nUjW6P"),
                    new Statistics(0, 0),
                    Status.Cancelled)
            };
    }
}
