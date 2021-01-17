namespace BettingSystem.Infrastructure
{
    using System;
    using System.Reflection;
    using Application.Betting.Bets;
    using Application.Betting.Gamblers;
    using Application.Betting.Matches;
    using Application.Championships.Tournaments;
    using Application.Teams;
    using AutoMapper;
    using Betting;
    using Championships;
    using Common.Persistence;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
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
                .AddScoped<IBettingDbContext>(provider => provider
                    .GetService<BettingDbContext>()!)
                .AddScoped<ITeamsDbContext>(provider => provider
                    .GetService<BettingDbContext>()!)
                .AddScoped<ITournamentsDbContext>(provider => provider
                    .GetService<BettingDbContext>()!);

            var services = serviceCollection
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddRepositories()
                .BuildServiceProvider();

            services
                .GetService<IGamblerQueryRepository>()
                .Should()
                .NotBeNull();

            services
                .GetService<IMatchQueryRepository>()
                .Should()
                .NotBeNull();

            services
                .GetService<IBetQueryRepository>()
                .Should()
                .NotBeNull();

            services
                .GetService<ITeamQueryRepository>()
                .Should()
                .NotBeNull();

            services
                .GetService<ITournamentQueryRepository>()
                .Should()
                .NotBeNull();
        }
    }
}
