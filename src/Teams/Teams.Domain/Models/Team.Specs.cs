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
        [InlineData("", 0)]
        [InlineData("cs", 1)]
        [InlineData(null, 2)]
        public void InvalidTeamShouldThrowException(string name, int points)
        {
            Action act = () => new Team(name, points);

            act.Should().Throw<InvalidTeamException>();
        }
    }
}
