namespace BettingSystem.Domain
{
    using System.Linq;
    using Betting.Factories.Bets;
    using Common;
    using FluentAssertions;
    using Matches.Factories;
    using Microsoft.Extensions.DependencyInjection;
    using Teams.Factories;
    using Xunit;

    public class DomainConfigurationSpecs
    {
        [Fact]
        public void AddDomainShouldRegisterFactories()
        {
            var serviceCollection = new ServiceCollection();

            var services = serviceCollection
                .AddDomain()
                .BuildServiceProvider();

            services
                .GetService<IBetFactory>()
                .Should()
                .NotBeNull();

            services
                .GetService<ITeamFactory>()
                .Should()
                .NotBeNull();

            services
                .GetService<IMatchFactory>()
                .Should()
                .NotBeNull();
        }

        [Fact]
        public void AddDomainShouldRegisterInitialData()
        {
            var serviceCollection = new ServiceCollection();

            var services = serviceCollection
                .AddDomain()
                .BuildServiceProvider();

            services
                .GetServices<IInitialData>()
                .ToList()
                .ForEach(initialData => initialData
                    .Should()
                    .NotBeNull());
        }
    }
}
