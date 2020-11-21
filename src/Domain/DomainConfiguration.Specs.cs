namespace BettingSystem.Domain
{
    using Factories.Bets;
    using Factories.Gamblers;
    using Factories.Matches;
    using Factories.Teams;
    using FluentAssertions;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class DomainConfigurationSpecs
    {
        [Fact]
        public void AddDomainShouldRegisterFactories()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();

            // Act
            var services = serviceCollection
                .AddDomain()
                .BuildServiceProvider();

            // Assert
            services
                .GetService<IBetFactory>()
                .Should()
                .NotBeNull();

            services
                .GetService<IGamblerFactory>()
                .Should()
                .NotBeNull();

            services
                .GetService<IMatchFactory>()
                .Should()
                .NotBeNull();

            services
                .GetService<ITeamFactory>()
                .Should()
                .NotBeNull();
        }
    }
}
