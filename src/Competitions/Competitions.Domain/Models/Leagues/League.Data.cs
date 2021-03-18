namespace BettingSystem.Domain.Competitions.Models.Leagues
{
    using System;
    using System.Collections.Generic;
    using Common;

    internal class LeagueData : IInitialData
    {
        public Type EntityType => typeof(League);

        public IEnumerable<object> GetData()
            => new List<League>
            {
                new League("La Liga"),
                new League("Premier League")
            };
    }
}
