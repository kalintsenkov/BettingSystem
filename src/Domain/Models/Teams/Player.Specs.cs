namespace BettingSystem.Domain.Models.Teams
{
    using System;
    using Exceptions;
    using FakeItEasy;
    using FluentAssertions;
    using Xunit;

    public class PlayerSpecs
    {
        [Fact]
        public void ValidPlayerShouldNotThrowException()
        {
            // Act
            Action act = () => A.Dummy<Player>();

            // Assert
            act.Should().NotThrow<InvalidTeamException>();
        }

        [Theory]
        [InlineData("")]
        [InlineData("cs")]
        [InlineData(null)]
        public void InvalidPlayerShouldThrowException(string name)
        {
            // Act
            Action act = () => new Player(name, Position.Forward);

            // Assert
            act.Should().Throw<InvalidTeamException>();
        }
    }
}
