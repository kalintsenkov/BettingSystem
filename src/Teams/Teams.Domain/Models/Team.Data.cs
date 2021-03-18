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
                new Team("Man City"),
                new Team("Man United"),
                new Team("Real Madrid"),
                new Team("Barcelona"),
                new Team("Arsenal"),
                new Team("Chelsea")
            };
    }
}
