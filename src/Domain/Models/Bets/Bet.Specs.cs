namespace BettingSystem.Domain.Models.Bets
{
    using System;
    using Exceptions;
    using FakeItEasy;
    using FluentAssertions;
    using Matches;
    using Xunit;

    public class BetSpecs
    {
        [Fact]
        public void ValidBetShouldNotThrowException()
        {
            Action act = () => new Bet(A.Dummy<Match>(), 55.5m, Prediction.Home, true);

            act.Should().NotThrow<InvalidBetException>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void InvalidBetAmountShouldThrowException(decimal amount)
        {
            Action act = () => new Bet(A.Dummy<Match>(), amount, Prediction.Away, false);

            act.Should().Throw<InvalidBetException>();
        }

        [Fact]
        public void MakeProfitableShouldSetIsProfitableToTrueIfBetPredictionIsCorrect()
        {
            var match = A.Dummy<Match>();
            var bet = new Bet(match, 55.5m, Prediction.Home, false);

            match.Finish();

            bet.MakeProfitable();

            bet.IsProfitable.Should().BeTrue();
        }

        [Fact]
        public void MakeProfitableShouldThrowExceptionIfMatchIsNotFinished()
        {
            var match = new Match(
                DateTime.Today,
                A.Dummy<Team>(),
                A.Dummy<Team>(),
                A.Dummy<Stadium>(),
                A.Dummy<Statistics>(),
                Status.NotStarted);

            var bet = new Bet(match, 55.5m, Prediction.Home, false);

            Action act = () => bet.MakeProfitable();

            act.Should().Throw<InvalidBetException>();
        }
    }
}
