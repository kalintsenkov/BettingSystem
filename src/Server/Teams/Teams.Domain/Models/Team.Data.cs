namespace BettingSystem.Domain.Teams.Models
{
    using System;
    using System.Collections.Generic;
    using Common;

    internal class TeamData : IInitialData
    {
        public Type EntityType => typeof(Team);

        public IEnumerable<object> GetData()
            => new List<Team>
            {
                new("Man City"),
                new("Man United"),
                new("Real Madrid"),
                new("Barcelona")
            };
    }
}
