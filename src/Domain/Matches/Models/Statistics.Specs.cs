namespace BettingSystem.Domain.Matches.Models
{
    using System;
    using Exceptions;
    using FluentAssertions;
    using Xunit;

    public class StatisticsSpecs
    {
        [Theory]
        [InlineData(3, 0)]
        [InlineData(0, 3)]
        [InlineData(null, null)]
        public void ValidStatisticShouldNotThrowException(int? homeScore, int? awayScore)
        {
            Action act = () => new Statistics(homeScore, awayScore);

            act.Should().NotThrow<InvalidMatchException>();
        }

        [Theory]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        [InlineData(-1, -1)]
        public void InvalidStatisticShouldThrowException(int homeScore, int awayScore)
        {
            Action act = () => new Statistics(homeScore, awayScore);

            act.Should().Throw<InvalidMatchException>();
        }
    }
}
