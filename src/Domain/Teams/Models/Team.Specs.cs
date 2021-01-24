namespace BettingSystem.Domain.Teams.Models
{
    using System;
    using Exceptions;
    using FakeItEasy;
    using FluentAssertions;
    using Xunit;

    public class TeamSpecs
    {
        [Fact]
        public void ValidTeamShouldNotThrowException()
        {
            Action act = () => A.Dummy<Team>();

            act.Should().NotThrow<InvalidTeamException>();
        }

        [Theory]
        [InlineData("", 1, 0)]
        [InlineData("cs", 1, 1)]
        [InlineData(null, 1, 2)]
        public void InvalidTeamShouldThrowException(string name, int leagueId, int points)
        {
            Action act = () => new Team(name, leagueId, points);

            act.Should().Throw<InvalidTeamException>();
        }
    }
}
