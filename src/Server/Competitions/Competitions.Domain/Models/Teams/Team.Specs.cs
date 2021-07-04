namespace BettingSystem.Domain.Competitions.Models.Teams
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
        [InlineData("", -1)]
        [InlineData("cs", 0)]
        [InlineData(null, 1)]
        public void InvalidTeamShouldThrowException(string name, int points)
        {
            Action act = () => new Team(name, points);

            act.Should().Throw<InvalidTeamException>();
        }
    }
}
