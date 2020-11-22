namespace BettingSystem.Domain.Models.Matches
{
    using System;
    using Bogus;
    using Common;
    using FakeItEasy;
    using Teams;

    public class MatchFakes
    {
        public class MatchDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(Match);

            public object? Create(Type type)
                => new Faker<Match>()
                    .CustomInstantiator(f => new Match(
                        DateTime.UtcNow,
                        A.Dummy<Team>(),
                        A.Dummy<Team>(),
                        A.Dummy<Stadium>(),
                        A.Dummy<Statistics>()))
                    .Generate()
                    .SetId(1);

            public Priority Priority => Priority.Default;
        }
    }
}
