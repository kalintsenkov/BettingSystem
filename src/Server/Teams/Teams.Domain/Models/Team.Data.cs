namespace BettingSystem.Domain.Teams.Models
{
    using System;
    using System.Collections.Generic;
    using Common;
    using Common.Models.Images;

    internal class TeamData : IInitialData
    {
        public Type EntityType => typeof(Team);

        public IEnumerable<object> GetData()
            => new List<Team>
            {
                new("Man City", new Image(
                    Array.Empty<byte>(),
                    Array.Empty<byte>())),
                new("Man United", new Image(
                    Array.Empty<byte>(),
                    Array.Empty<byte>())),
                new("Real Madrid", new Image(
                    Array.Empty<byte>(),
                    Array.Empty<byte>())),
                new("Barcelona", new Image(
                    Array.Empty<byte>(),
                    Array.Empty<byte>()))
            };
    }
}
