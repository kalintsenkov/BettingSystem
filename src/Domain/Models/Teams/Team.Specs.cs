namespace BettingSystem.Domain.Models.Teams
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
            // Act
            Action act = () => A.Dummy<Team>();

            // Assert
            act.Should().NotThrow<InvalidTeamException>();
        }

        [Theory]
        [InlineData("")]
        [InlineData("cs")]
        [InlineData(null)]
        public void InvalidTeamShouldThrowException(string name)
        {
            // Act
            Action act = () => new Team(name);

            // Assert
            act.Should().Throw<InvalidTeamException>();
        }
    }
}
