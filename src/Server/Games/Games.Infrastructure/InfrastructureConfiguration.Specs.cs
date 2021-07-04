namespace BettingSystem.Infrastructure.Games
{
    using System;
    using System.Reflection;
    using Application.Games.Matches;
    using Application.Games.Teams;
    using Common;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Persistence;
    using Xunit;
    using static Common.InfrastructureConfigurationFakes;

    public class InfrastructureConfigurationSpecs
    {
        [Fact]
        public void AddRepositoriesShouldRegisterRepositories()
        {
            var serviceCollection = new ServiceCollection()
                .AddDbContext<GamesDbContext>(options => options
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()));

            var assembly = Assembly.GetExecutingAssembly();

            var services = serviceCollection
                .AddAutoMapper(assembly)
                .AddRepositories(assembly)
                .AddEvents(
                    configuration: FakeConfiguration,
                    usePolling: false)
                .BuildServiceProvider();

            services
                .GetService<IMatchQueryRepository>()
                .Should()
                .NotBeNull();

            services
                .GetService<ITeamQueryRepository>()
                .Should()
                .NotBeNull();
        }
    }
}
