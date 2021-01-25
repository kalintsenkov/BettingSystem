namespace BettingSystem.Domain.Competitions.Models.Matches
{
    using System;
    using System.Collections.Generic;
    using Common;
    using Leagues;

    internal class MatchData : IInitialData
    {
        private readonly League league = new League("Premier League");

        public Type EntityType => typeof(Match);

        public IEnumerable<object> GetData()
            => new List<Match>
            {
                new Match(
                    DateTime.Today.AddHours(5),
                    new Team("Man United", this.league, 0),
                    new Team("Man City", this.league, 0),
                    new Stadium("Old Trafford", "https://bit.ly/3miHWzW"),
                    new Statistics(null, null),
                    Status.NotStarted),

                new Match(
                    DateTime.Today.AddDays(2),
                    new Team("Barcelona", this.league, 0),
                    new Team("Real Madrid", this.league, 0),
                    new Stadium("Camp Nou", "https://fifa.fans/2UZdIWH"),
                    new Statistics(0, 3),
                    Status.FirstHalf),

                new Match(
                    DateTime.Today.AddDays(3),
                    new Team("Chelsea", this.league, 0),
                    new Team("Arsenal", this.league, 0),
                    new Stadium("Stamford Bridge", "https://bit.ly/3nUjW6P"),
                    new Statistics(0, 0),
                    Status.Cancelled)
            };
    }
}
