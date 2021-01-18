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
            Action act = () => GetStadium(string.Empty, string.Empty);

            act.Should().Throw<InvalidMatchException>();
        }

        [Theory]
        [InlineData(null, "https://validimageurl.com")]
        [InlineData("", "https://validimageurl.com")]
        [InlineData("cs", "https://validimageurl.com")]
        public void InvalidNameShouldThrowException(string name, string imageUrl)
        {
            Action act = () => GetStadium(name, imageUrl);

            act.Should().Throw<InvalidMatchException>();
        }

        [Theory]
        [InlineData("ValidStadium", "")]
        [InlineData("ValidStadium", "invalidimageurl.com")]
        public void InvalidImageUrlShouldThrowException(string name, string imageUrl)
        {
            Action act = () => GetStadium(name, imageUrl);

            act.Should().Throw<InvalidMatchException>();
        }
    }
}
