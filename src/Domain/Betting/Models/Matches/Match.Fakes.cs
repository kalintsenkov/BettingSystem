namespace BettingSystem.Domain.Betting.Models.Matches
{
    using System;
    using Bogus;
    using Common.Models;
    using FakeItEasy;

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
                        A.Dummy<Statistics>(),
                        Status.InPlay))
                    .Generate()
                    .SetId(1);

            public Priority Priority => Priority.Default;
        }
    }
}
