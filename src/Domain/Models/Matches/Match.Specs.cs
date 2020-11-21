namespace BettingSystem.Domain.Models.Matches
{
    using FakeItEasy;
    using FluentAssertions;
    using Xunit;

    public class MatchSpecs
    {
        [Fact]
        public void GetResultShouldReturnWinningTeam()
        {
            // Arrange
            var match = A.Dummy<Match>();

            // Act
            var result = match.GetResult();

            // Assert
            result.Should().Be(Result.Home);
        }
    }
}
