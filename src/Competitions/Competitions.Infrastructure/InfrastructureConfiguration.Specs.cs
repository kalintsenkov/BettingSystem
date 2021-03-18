namespace BettingSystem.Infrastructure.Competitions
{
    using System;
    using System.Reflection;
    using Application.Competitions.Leagues;
    using Common.Configuration;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Persistence;
    using Xunit;

    public class InfrastructureConfigurationSpecs
    {
        [Fact]
        public void AddRepositoriesShouldRegisterRepositories()
        {
            var serviceCollection = new ServiceCollection()
                .AddDbContext<CompetitionsDbContext>(options => options
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()))
                .AddScoped<ICompetitionsDbContext>(provider => provider
                    .GetService<CompetitionsDbContext>()!);

            var assembly = Assembly.GetExecutingAssembly();

            var services = serviceCollection
                .AddAutoMapper(assembly)
                .AddRepositories(assembly)
                .BuildServiceProvider();

            services
                .GetService<ILeagueQueryRepository>()
                .Should()
                .NotBeNull();
        }
    }
}
