namespace BettingSystem.Domain.Betting.Models.Matches
{
    using System;
    using Bogus;
    using Common.Models;
    using FakeItEasy;

    public class StadiumFakes
    {
        public class StadiumDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(Stadium);

            public object? Create(Type type) => Data.GetStadium();

            public Priority Priority => Priority.Default;
        }

        public static class Data
        {
            public static Stadium GetStadium(int id = 1)
                => new Faker<Stadium>()
                    .CustomInstantiator(f => new Stadium(
                        $"Stadium {id}",
                        f.Image.PicsumUrl()))
                    .Generate()
                    .SetId(id);

            public static Stadium GetStadium(
                string name,
                string imageUrl,
                int id = 1)
                => new Faker<Stadium>()
                    .CustomInstantiator(f => new Stadium(
                        name,
                        imageUrl))
                    .Generate()
                    .SetId(id);
        }
    }
}
