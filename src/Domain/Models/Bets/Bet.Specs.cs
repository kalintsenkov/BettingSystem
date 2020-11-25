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
            // Act
            Action act = () => new Bet(A.Dummy<Match>(), 55.5m, Prediction.Home, true);

            // Assert
            act.Should().NotThrow<InvalidBetException>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void InvalidBetAmountShouldThrowException(decimal amount)
        {
            // Act
            Action act = () => new Bet(A.Dummy<Match>(), amount, Prediction.Away, false);

            // Assert
            act.Should().Throw<InvalidBetException>();
        }
    }
}
