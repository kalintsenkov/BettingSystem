namespace BettingSystem.Domain.Competitions.Models.Leagues
{
    using System;
    using System.Collections.Generic;
    using Common;
    using Teams;

    internal class LeagueData : IInitialData
    {
        public Type EntityType => typeof(League);

        public IEnumerable<object> GetData()
            => new List<League>
            {
                new(
                    name: "Premier League",
                    teams: new HashSet<Team>
                    {
                        new("Man City", 0),
                        new("Man United", 0)
                    }),

                new(
                    name: "La Liga",
                    teams: new HashSet<Team>
                    {
                        new("Real Madrid", 0),
                        new("Barcelona", 0)
                    })
            };
    }
}
