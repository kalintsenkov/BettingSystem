﻿namespace BettingSystem.Domain.Betting.Models.Bets
{
    using System;
    using Exceptions;
    using FluentAssertions;
    using Matches;
    using Xunit;

    public class BetSpecs
    {
        [Fact]
        public void ValidBetShouldNotThrowException()
        {
            var match = new Match(
                DateTime.Today,
                new Statistics(0, 3),
                Status.NotStarted);

            Action act = () => new Bet(
                match,
                55.5m,
                Prediction.Home,
                true);

            act.Should().NotThrow<InvalidBetException>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void InvalidBetAmountShouldThrowException(decimal amount)
        {
            var match = new Match(
                DateTime.Today,
                new Statistics(3, 0),
                Status.NotStarted);

            Action act = () => new Bet(
                match,
                amount,
                Prediction.Away,
                false);

            act.Should().Throw<InvalidBetException>();
        }

        [Fact]
        public void MakeProfitableShouldSetIsProfitableToTrueIfBetPredictionIsCorrect()
        {
            var match = new Match(
                DateTime.Today,
                new Statistics(3, 0),
                Status.NotStarted);

            var bet = new Bet(
                match,
                55.5m,
                Prediction.Home,
                false);

            match.UpdateStatus(Status.Finished);

            bet.MakeProfitable();

            bet.IsProfitable.Should().BeTrue();
        }

        [Fact]
        public void MakeProfitableShouldThrowExceptionIfMatchIsNotFinished()
        {
            var match = new Match(
                DateTime.Today,
                new Statistics(3, 0),
                Status.FirstHalf);

            var bet = new Bet(
                match,
                55.5m,
                Prediction.Home,
                false);

            Action act = () => bet.MakeProfitable();

            act.Should().Throw<InvalidBetException>();
        }
    }
}
