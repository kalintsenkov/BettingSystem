namespace BettingSystem.Domain.Models.Matches
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
        [InlineData("")]
        [InlineData("cs")]
        [InlineData(null)]
        public void InvalidTeamShouldThrowException(string name)
        {
            Action act = () => new Team(name);

            act.Should().Throw<InvalidTeamException>();
        }
    }
}
