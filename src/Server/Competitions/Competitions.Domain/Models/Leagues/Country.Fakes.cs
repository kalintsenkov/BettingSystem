namespace BettingSystem.Domain.Competitions.Models.Leagues
{
    using System;
    using Bogus;
    using Common.Models;
    using FakeItEasy;

    using static Common.Models.ModelConstants.Common;

    public class CountryFakes
    {
        public class CountryDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(Country);

            public object? Create(Type type)
                => new Faker<Country>()
                    .CustomInstantiator(f => new Country(
                        f.Random.String2(
                            MinNameLength,
                            MaxNameLength)))
                    .Generate()
                    .SetId(1);

            public Priority Priority => Priority.Default;
        }
    }
}
