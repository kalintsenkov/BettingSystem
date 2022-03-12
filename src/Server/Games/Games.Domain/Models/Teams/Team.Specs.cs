namespace BettingSystem.Domain.Games.Models.Teams;

using System;
using Common.Models;
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
        Action act = () => new Team(name, A.Dummy<Image>());

        act.Should().Throw<InvalidTeamException>();
    }

    [Theory]
    [InlineData("Test 1")]
    [InlineData("Test 2")]
    [InlineData("Test 3")]
    public void UpdateNameShouldSetNewNameIfNameIsValid(string newName)
    {
        var team = A.Dummy<Team>();

        team.UpdateName(newName);

        team.Name.Should().Be(newName);
    }

    [Theory]
    [InlineData("")]
    [InlineData("cs")]
    [InlineData(null)]
    public void UpdateNameShouldThrowExceptionIfNameIsInvalid(string newName)
    {
        var team = A.Dummy<Team>();

        Action act = () => team.UpdateName(newName);

        act.Should().Throw<InvalidTeamException>();
    }
}