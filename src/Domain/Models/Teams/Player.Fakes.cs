namespace BettingSystem.Domain.Models.Teams
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Bogus;
    using Bogus.DataSets;
    using Common;
    using FakeItEasy;

    public class PlayerFakes
    {
        public class PlayerDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(Player);

            public object? Create(Type type) => Data.GetPlayer();

            public Priority Priority => Priority.Default;
        }

        public static class Data
        {
            public static IEnumerable<Player> GetPlayers(int count = 10)
                => Enumerable
                    .Range(1, count)
                    .Select(GetPlayer)
                    .Concat(Enumerable
                        .Range(count + 1, count * 2)
                        .Select(GetPlayer))
                    .ToList();

            public static Player GetPlayer(int id = 1)
                => new Faker<Player>()
                    .CustomInstantiator(f => new Player(
                        f.Name.FullName(Name.Gender.Male),
                        f.PickRandom(Enumeration.GetAll<Position>())))
                    .Generate()
                    .SetId(id);
        }
    }
}
