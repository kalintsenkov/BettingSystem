namespace BettingSystem.Domain.Games.Models.Matches
{
    using System;
    using Bogus;
    using Common.Models;
    using Common.Models.Images;
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
                    .CustomInstantiator(_ => new Stadium(
                        $"Stadium {id}",
                        A.Dummy<Image>()))
                    .Generate()
                    .SetId(id);

            public static Stadium GetStadium(
                string name,
                int id = 1)
                => new Faker<Stadium>()
                    .CustomInstantiator(_ => new Stadium(
                        name,
                        A.Dummy<Image>()))
                    .Generate()
                    .SetId(id);
        }
    }
}
