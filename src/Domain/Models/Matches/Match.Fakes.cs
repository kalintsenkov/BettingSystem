namespace BettingSystem.Domain.Models.Matches
{
    using System;
    using FakeItEasy;
    using Teams;

    public class MatchFakes
    {
        public class MatchDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(Match);

            public object? Create(Type type)
                => new Match(
                    DateTime.UtcNow,
                    new Team("Chelsea"),
                    new Team("Liverpool"),
                    new Stadium("Stamford Bridge", "https://image.com"),
                    new Statistics(3, 0));

            public Priority Priority => Priority.Default;
        }
    }
}
