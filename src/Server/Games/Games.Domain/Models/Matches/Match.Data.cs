namespace BettingSystem.Domain.Games.Models.Matches
{
    using System;
    using System.Collections.Generic;
    using Common;
    using Common.Models.Images;
    using Teams;

    internal class MatchData : IInitialData
    {
        public Type EntityType => typeof(Match);

        public IEnumerable<object> GetData()
            => new List<Match>
            {
                new(
                    DateTime.Today.AddHours(5),
                    new Team(
                        "Man United",
                        new Image(
                            Array.Empty<byte>(),
                            Array.Empty<byte>())),
                    new Team(
                        "Man City",
                        new Image(
                            Array.Empty<byte>(),
                            Array.Empty<byte>())),
                    new Stadium(
                        "Old Trafford",
                        new Image(
                            Array.Empty<byte>(),
                            Array.Empty<byte>())),
                    new Statistics(null, null),
                    Status.NotStarted),

                new(
                    DateTime.Today.AddDays(2),
                    new Team(
                        "Barcelona",
                        new Image(
                            Array.Empty<byte>(),
                            Array.Empty<byte>())),
                    new Team(
                        "Real Madrid",
                        new Image(
                            Array.Empty<byte>(),
                            Array.Empty<byte>())),
                    new Stadium(
                        "Camp Nou",
                        new Image(
                            Array.Empty<byte>(),
                            Array.Empty<byte>())),
                    new Statistics(0, 3),
                    Status.FirstHalf)
            };
    }
}
