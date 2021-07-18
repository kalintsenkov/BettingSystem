namespace BettingSystem.Domain.Competitions.Models.Leagues
{
    using System;
    using Exceptions;
    using FakeItEasy;
    using FluentAssertions;
    using Teams;
    using Xunit;

    public class LeagueSpecs
    {
        [Fact]
        public void ValidLeagueShouldNotThrowException()
        {
            Action act = () => A.Dummy<League>();

            act.Should().NotThrow<InvalidLeagueException>();
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public void InvalidMatchDateShouldThrowException(string name)
        {
            Action act = () => new League(name);

            act.Should().Throw<InvalidLeagueException>();
        }

        [Theory]
        [InlineData("Test 1")]
        [InlineData("Test 2")]
        [InlineData("Test 3")]
        public void UpdateNameShouldSetNewNameIfNameIsValid(string newName)
        {
            var league = A.Dummy<League>();

            league.UpdateName(newName);

            league.Name.Should().Be(newName);
        }

        [Theory]
        [InlineData("")]
        [InlineData("cs")]
        [InlineData(null)]
        public void UpdateNameShouldThrowExceptionIfNameIsInvalid(string newName)
        {
            var league = A.Dummy<League>();

            Action act = () => league.UpdateName(newName);

            act.Should().Throw<InvalidLeagueException>();
        }

        [Fact]
        public void AddTeamShouldWork()
        {
            var league = A.Dummy<League>();

            var team = A.Dummy<Team>();

            league.AddTeam(team);

            league.Teams.Count.Should().Be(1);
            league.Teams.Should().Contain(team);
        }
    }
}
