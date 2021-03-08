namespace BettingSystem.Domain.Competitions.Models.Leagues
{
    using System;
    using Bogus;
    using Common.Models;
    using FakeItEasy;

    using static Common.Models.ModelConstants.Common;

    public class LeagueFakes
    {
        public class LeagueDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(League);

            public object? Create(Type type)
                => new Faker<League>()
                    .CustomInstantiator(f => new League(
                        f.Random.String2(
                            MinNameLength,
                            MaxNameLength)))
                    .Generate()
                    .SetId(1);

            public Priority Priority => Priority.Default;
        }
    }
}
