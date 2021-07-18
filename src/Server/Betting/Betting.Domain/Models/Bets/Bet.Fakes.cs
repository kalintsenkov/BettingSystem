namespace BettingSystem.Domain.Betting.Models.Bets
{
    using System;
    using Bogus;
    using Common.Models;
    using FakeItEasy;
    using Matches;

    using static ModelConstants.Bet;

    public class BetFakes
    {
        public class BetDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(Bet);

            public object? Create(Type type)
                => new Faker<Bet>()
                    .CustomInstantiator(f => new Bet(
                        A.Dummy<Match>(),
                        f.Random.Decimal(MinAmountValue),
                        f.PickRandomParam(
                            Prediction.Away,
                            Prediction.Draw,
                            Prediction.Home),
                        f.Random.Bool()))
                    .Generate()
                    .SetId(1);

            public Priority Priority => Priority.Default;
        }
    }
}
