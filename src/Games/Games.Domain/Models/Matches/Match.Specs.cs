namespace BettingSystem.Domain.Games.Models.Matches
{
    using System;
    using Exceptions;
    using FakeItEasy;
    using FluentAssertions;
    using Teams;
    using Xunit;

    public class MatchSpecs
    {
        [Fact]
        public void ValidMatchShouldNotThrowException()
        {
            Action act = () => A.Dummy<Match>();

            act.Should().NotThrow<InvalidMatchException>();
        }

        [Fact]
        public void InvalidMatchDateShouldThrowException()
        {
            Action act = () => new Match(
                DateTime.Today.AddDays(-1),
                A.Dummy<Team>(),
                A.Dummy<Team>(),
                A.Dummy<Stadium>(),
                A.Dummy<Statistics>(),
                Status.NotStarted);

            act.Should().Throw<InvalidMatchException>();
        }
    }
}
