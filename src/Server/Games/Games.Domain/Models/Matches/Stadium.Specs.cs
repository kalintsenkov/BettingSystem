namespace BettingSystem.Domain.Games.Models.Matches
{
    using System;
    using Exceptions;
    using FakeItEasy;
    using FluentAssertions;
    using Xunit;
    using static StadiumFakes.Data;

    public class StadiumSpecs
    {
        [Fact]
        public void ValidStadiumShouldNotThrowException()
        {
            Action act = () => A.Dummy<Stadium>();

            act.Should().NotThrow<InvalidMatchException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("cs")]
        public void InvalidNameShouldThrowException(string name)
        {
            Action act = () => GetStadium(name);

            act.Should().Throw<InvalidMatchException>();
        }
    }
}
