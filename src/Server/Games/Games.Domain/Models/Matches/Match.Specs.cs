namespace BettingSystem.Domain.Games.Models.Matches;

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

    [Fact]
    public void UpdateStartDateShouldSetNewStartDateIfDateIsValid()
    {
        var match = A.Dummy<Match>();

        var nextWeek = DateTime.Today.AddDays(7);

        match.UpdateStartDate(nextWeek);

        match.StartDate.Should().Be(nextWeek);
    }

    [Fact]
    public void UpdateStartDateShouldThrowExceptionIfDateIsInvalid()
    {
        var match = A.Dummy<Match>();

        var previousWeek = DateTime.Today.AddDays(-7);

        Action act = () => match.UpdateStartDate(previousWeek);

        act.Should().Throw<InvalidMatchException>();
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 0)]
    [InlineData(0, 1)]
    public void UpdateStatisticsShouldSetNewHomeAndAwayScore(int homeScore, int awayScore)
    {
        var match = A.Dummy<Match>();

        match.UpdateStatistics(homeScore, awayScore);

        match.Statistics.HomeScore.Should().Be(homeScore);
        match.Statistics.AwayScore.Should().Be(awayScore);
    }

    [Fact]
    public void StartFirstHalfShouldSetNewStatus()
    {
        var match = A.Dummy<Match>();

        match.StartFirstHalf();

        match.Status.Should().Be(Status.FirstHalf);
    }

    [Fact]
    public void StartFirstHalfShouldSetHomeAndAwayScoreToZero()
    {
        var match = A.Dummy<Match>();

        match.StartFirstHalf();

        match.Statistics.HomeScore.Should().Be(0);
        match.Statistics.AwayScore.Should().Be(0);
    }

    [Fact]
    public void HalfTimeShouldSetNewStatus()
    {
        var match = A.Dummy<Match>();

        match.HalfTime();

        match.Status.Should().Be(Status.HalfTime);
    }

    [Fact]
    public void HalfTimeShouldSetHalfTimeScore()
    {
        var match = A.Dummy<Match>();

        match.HalfTime();

        match.Statistics.HalfTimeHomeScore.Should().NotBeNull();
        match.Statistics.HalfTimeAwayScore.Should().NotBeNull();
        match.Statistics.HalfTimeHomeScore.Should().Be(match.Statistics.HomeScore);
        match.Statistics.HalfTimeAwayScore.Should().Be(match.Statistics.AwayScore);
    }

    [Fact]
    public void HalfTimeShouldThrowExceptionIfMatchIsNotStarted()
    {
        var match = new Match(
            DateTime.Today,
            A.Dummy<Team>(),
            A.Dummy<Team>(),
            A.Dummy<Stadium>(),
            A.Dummy<Statistics>(),
            Status.NotStarted);

        Action act = () => match.HalfTime();

        act.Should().Throw<InvalidMatchException>();
    }

    [Fact]
    public void StartSecondHalfShouldSetNewStatus()
    {
        var match = A.Dummy<Match>();

        match.StartSecondHalf();

        match.Status.Should().Be(Status.SecondHalf);
    }

    [Fact]
    public void StartSecondHalfShouldThrowExceptionIfMatchIsNotStarted()
    {
        var match = new Match(
            DateTime.Today,
            A.Dummy<Team>(),
            A.Dummy<Team>(),
            A.Dummy<Stadium>(),
            A.Dummy<Statistics>(),
            Status.NotStarted);

        Action act = () => match.StartSecondHalf();

        act.Should().Throw<InvalidMatchException>();
    }

    [Fact]
    public void FinishShouldSetNewStatus()
    {
        var match = A.Dummy<Match>();

        match.Finish();

        match.Status.Should().Be(Status.Finished);
    }

    [Fact]
    public void FinishShouldThrowExceptionIfMatchIsNotStarted()
    {
        var match = new Match(
            DateTime.Today,
            A.Dummy<Team>(),
            A.Dummy<Team>(),
            A.Dummy<Stadium>(),
            A.Dummy<Statistics>(),
            Status.NotStarted);

        Action act = () => match.Finish();

        act.Should().Throw<InvalidMatchException>();
    }

    [Fact]
    public void CancelShouldSetNewStatus()
    {
        var match = A.Dummy<Match>();

        match.Cancel();

        match.Status.Should().Be(Status.Cancelled);
    }
}