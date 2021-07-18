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
        [InlineData("")]
        [InlineData("cs")]
        [InlineData(null)]
        public void InvalidTeamShouldThrowException(string name)
        {
            Action act = () => new Team(name);

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

        [Theory]
        [InlineData("Test 1")]
        [InlineData("Test 2")]
        [InlineData("Test 3")]
        public void AddPlayerShouldWork(string playerName)
        {
            var team = A.Dummy<Team>();

            team.AddPlayer(playerName, Position.Forward);

            team.Players.Count.Should().Be(1);
            team.Players.Should().ContainSingle(p => p.Name == playerName);
        }
    }
}
