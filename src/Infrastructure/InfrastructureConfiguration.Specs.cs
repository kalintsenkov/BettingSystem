namespace BettingSystem.Infrastructure
{
    using System;
    using System.Reflection;
    using Application.Betting.Bets;
    using Application.Betting.Gamblers;
    using Application.Competitions.Leagues;
    using Application.Competitions.Matches;
    using Application.Teams;
    using AutoMapper;
    using Betting;
    using Common.Persistence;
    using Competitions;
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
                .AddScoped<ICompetitionsDbContext>(provider => provider
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
                .GetService<ILeagueQueryRepository>()
                .Should()
                .NotBeNull();
        }
    }
}
