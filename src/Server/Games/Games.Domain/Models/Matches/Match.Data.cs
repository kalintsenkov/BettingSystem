namespace BettingSystem.Domain.Games.Models.Matches
{
    using System;
    using System.Collections.Generic;
    using Common;
    using Common.Models.Images;
    using Teams;

    internal class MatchData : IInitialData
    {
        private readonly Image emptyImage = new(
            Array.Empty<byte>(),
            Array.Empty<byte>());

        public Type EntityType => typeof(Match);

        public IEnumerable<object> GetData()
            => new List<Match>
            {
                new(
                    DateTime.Today.AddHours(5),
                    new Team("Man United", this.emptyImage),
                    new Team("Man City", this.emptyImage),
                    new Stadium("Old Trafford", this.emptyImage),
                    new Statistics(null, null),
                    Status.NotStarted),

                new(
                    DateTime.Today.AddDays(2),
                    new Team("Barcelona", this.emptyImage),
                    new Team("Real Madrid", this.emptyImage),
                    new Stadium("Camp Nou", this.emptyImage),
                    new Statistics(0, 3),
                    Status.FirstHalf)
            };
    }
}
