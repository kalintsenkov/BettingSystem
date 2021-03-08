namespace BettingSystem.Infrastructure
{
    using System;
    using System.Reflection;
    using Application.Competitions.Leagues;
    using Application.Teams;
    using Common.Configuration;
    using Common.Events;
    using Competitions;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Persistence;
    using Teams;
    using Xunit;

    public class InfrastructureConfigurationSpecs
    {
        [Fact]
        public void AddRepositoriesShouldRegisterRepositories()
        {
            var serviceCollection = new ServiceCollection()
                .AddDbContext<BettingDbContext>(options => options
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()))
                .AddScoped<ITeamsDbContext>(provider => provider
                    .GetService<BettingDbContext>()!)
                .AddScoped<ICompetitionsDbContext>(provider => provider
                    .GetService<BettingDbContext>()!)
                .AddTransient<IEventDispatcher, EventDispatcher>();

            var services = serviceCollection
                .AddAutoMapper(Assembly.GetCallingAssembly())
                .AddRepositories()
                .BuildServiceProvider();

            services
                .GetService<ITeamQueryRepository>()
                .Should()
                .NotBeNull();

            services
                .GetService<ILeagueQueryRepository>()
                .Should()
                .NotBeNull();
        }
    }
}
