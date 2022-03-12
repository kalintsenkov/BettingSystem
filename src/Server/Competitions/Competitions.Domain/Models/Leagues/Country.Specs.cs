namespace BettingSystem.Domain.Competitions.Models.Leagues;

using System;
using Exceptions;
using FakeItEasy;
using FluentAssertions;
using Xunit;

public class CountrySpecs
{
    [Fact]
    public void ValidCountryShouldNotThrowException()
    {
        Action act = () => A.Dummy<Country>();

        act.Should().NotThrow<InvalidLeagueException>();
    }

    [Theory]
    [InlineData("")]
    [InlineData("  ")]
    [InlineData(null)]
    public void InvalidMatchDateShouldThrowException(string name)
    {
        Action act = () => new Country(name);

        act.Should().Throw<InvalidLeagueException>();
    }
}