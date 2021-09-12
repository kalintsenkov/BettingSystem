namespace BettingSystem.Domain.Teams.Models
{
    using System;
    using System.Collections.Generic;
    using Common;
    using Common.Models.Images;

    internal class TeamData : IInitialData
    {
        private readonly Image emptyImage = new(
            Array.Empty<byte>(),
            Array.Empty<byte>());

        public Type EntityType => typeof(Team);

        public IEnumerable<object> GetData()
            => new List<Team>
            {
                new("Man City", this.emptyImage),
                new("Man United", this.emptyImage),
                new("Real Madrid", this.emptyImage),
                new("Barcelona", this.emptyImage)
            };
    }
}
