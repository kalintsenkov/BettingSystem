namespace BettingSystem.Domain.Teams.Models
{
    using System;
    using Bogus;
    using Common.Models;
    using FakeItEasy;

    using static Common.Models.ModelConstants.Common;

    public class CoachFakes
    {
        public class CoachDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(Coach);

            public object? Create(Type type)
                => new Faker<Coach>()
                    .CustomInstantiator(f => new Coach(
                        f.Random.String2(
                            MinNameLength,
                            MaxNameLength)))
                    .Generate()
                    .SetId(1);

            public Priority Priority => Priority.Default;
        }
    }
}
