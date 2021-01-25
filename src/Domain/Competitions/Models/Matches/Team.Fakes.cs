namespace BettingSystem.Domain.Competitions.Models.Matches
{
    using System;
    using Bogus;
    using Common.Models;
    using FakeItEasy;
    using Leagues;

    using static Common.Models.ModelConstants.Common;

    public class TeamFakes
    {
        public class TeamDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(Team);

            public object? Create(Type type)
                => new Faker<Team>()
                    .CustomInstantiator(f => new Team(
                        f.Random.String2(
                            MinNameLength,
                            MaxNameLength),
                        f.Random.Number(),
                        A.Dummy<League>()))
                    .Generate()
                    .SetId(1);

            public Priority Priority => Priority.Default;
        }
    }
}
