namespace BettingSystem.Domain.Common.Models
{
    using Betting.Models.Bets;
    using FluentAssertions;
    using Xunit;

    public class EnumerationSpecs
    {
        [Fact]
        public void EnumerationsWithEqualValuesShouldBeEqual()
        {
            // Arrange
            var first = Prediction.Home;
            var second = Prediction.Home;

            // Act
            var result = first == second;

            // Arrange
            result.Should().BeTrue();
        }

        [Fact]
        public void EnumerationsWithDifferentValuesShouldNotBeEqual()
        {
            // Arrange
            var first = Prediction.Home;
            var second = Prediction.Away;

            // Act
            var result = first == second;

            // Arrange
            result.Should().BeFalse();
        }
    }
}
