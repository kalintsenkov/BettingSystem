namespace BettingSystem.Domain.Betting.Models.Matches
{
    using System;
    using Bogus;
    using Common.Models;
    using FakeItEasy;

    using static Common.Models.ModelConstants.Common;

    public class StadiumFakes
    {
        public class StadiumDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(Stadium);

            public object? Create(Type type)
                => new Faker<Stadium>()
                    .CustomInstantiator(f => new Stadium(
                        f.Random.String2(
                            MinNameLength,
                            MaxNameLength),
                        A.Dummy<Image>()))
                    .Generate()
                    .SetId(1);

            public Priority Priority => Priority.Default;
        }
    }
}
