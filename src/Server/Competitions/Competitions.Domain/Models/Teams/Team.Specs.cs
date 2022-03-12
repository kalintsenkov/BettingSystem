namespace BettingSystem.Domain.Competitions.Models.Teams;

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

    [Fact]
    public void GivePointsForWinShouldAddThreePoints()
    {
        var team = A.Dummy<Team>();

        var points = team.Points;

        team.GivePointsForWin();

        team.Points.Should().Be(points + 3);
    }

    [Fact]
    public void GivePointFromDrawShouldAddOnePoint()
    {
        var team = A.Dummy<Team>();

        var points = team.Points;

        team.GivePointForDraw();

        team.Points.Should().Be(points + 1);
    }
}