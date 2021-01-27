namespace BettingSystem.Domain.Competitions.Models.Matches
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

        [Fact]
        public void InvalidNameAndImageUrlShouldThrowException()
        {
            Action act = () => GetStadium(string.Empty);

            act.Should().Throw<InvalidMatchException>();
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
