namespace BettingSystem.Domain.Models.Matches
{
    using System;
    using Common;
    using Exceptions;
    using FluentAssertions;
    using Xunit;

    public class StatisticsSpecs
    {
        [Theory]
        [InlineData(3, 0, "InPlay")]
        [InlineData(0, 3, "InPlay")]
        [InlineData(null, null, "NotStarted")]
        public void ValidStatisticShouldNotThrowException(int? homeScore, int? awayScore, string status)
        {
            // Act
            Action act = () => new Statistics(
                homeScore,
                awayScore,
                Enumeration.FromName<Status>(status));

            // Assert
            act.Should().NotThrow<InvalidMatchException>();
        }

        [Theory]
        [InlineData(-1, 0, "Cancelled")]
        [InlineData(0, -1, "Cancelled")]
        [InlineData(-1, -1, "Cancelled")]
        public void InvalidStatisticShouldThrowException(int homeScore, int awayScore, string status)
        {
            // Act
            Action act = () => new Statistics(
                homeScore,
                awayScore,
                Enumeration.FromName<Status>(status));

            // Assert
            act.Should().Throw<InvalidMatchException>();
        }
    }
}
