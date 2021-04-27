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
                new League(
                    name: "Premier League",
                    teams: new HashSet<Team>
                    {
                        new Team("Man City", 0),
                        new Team("Man United", 0)
                    }),

                new League(
                    name: "La Liga",
                    teams: new HashSet<Team>
                    {
                        new Team("Real Madrid", 0),
                        new Team("Barcelona", 0)
                    })
            };
    }
}
