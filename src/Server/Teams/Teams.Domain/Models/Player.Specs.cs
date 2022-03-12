namespace BettingSystem.Domain.Teams.Models;

using System;
using Exceptions;
using FluentAssertions;
using Xunit;

public class PlayerSpecs
{
    [Fact]
    public void ValidStadiumShouldNotThrowException()
    {
        Action act = () => new Player("test", Position.Forward);

        act.Should().NotThrow<InvalidTeamException>();
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("a")]
    [InlineData(null)]
    public void InvalidNameShouldThrowException(string name)
    {
        Action act = () => new Player(name, Position.Forward);

        act.Should().Throw<InvalidTeamException>();
    }
}