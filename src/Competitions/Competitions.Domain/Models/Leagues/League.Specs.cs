namespace BettingSystem.Domain.Competitions.Models.Leagues
{
    using System;
    using Exceptions;
    using FakeItEasy;
    using FluentAssertions;
    using Xunit;

    public class LeagueSpecs
    {
        [Fact]
        public void ValidLeagueShouldNotThrowException()
        {
            Action act = () => A.Dummy<League>();

            act.Should().NotThrow<InvalidLeagueException>();
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public void InvalidMatchDateShouldThrowException(string name)
        {
            Action act = () => new League(name);

            act.Should().Throw<InvalidLeagueException>();
        }
    }
}
