namespace BettingSystem.Domain.Teams.Models;

using System;
using Exceptions;
using FakeItEasy;
using FluentAssertions;
using Xunit;

public class CoachSpecs
{
    [Fact]
    public void ValidStadiumShouldNotThrowException()
    {
        Action act = () => A.Dummy<Coach>();

        act.Should().NotThrow<InvalidTeamException>();
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void InvalidNameShouldThrowException(string name)
    {
        Action act = () => new Coach(name);

        act.Should().Throw<InvalidTeamException>();
    }
}