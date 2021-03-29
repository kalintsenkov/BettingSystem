namespace BettingSystem.Infrastructure.Matches
{
    using System;
    using System.Reflection;
    using Application.Matches;
    using Common;
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
                .AddDbContext<MatchesDbContext>(options => options
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()))
                .AddScoped<IMatchesDbContext>(provider => provider
                    .GetService<MatchesDbContext>()!);

            var assembly = Assembly.GetExecutingAssembly();

            var services = serviceCollection
                .AddAutoMapper(assembly)
                .AddRepositories(assembly)
                .BuildServiceProvider();

            services
                .GetService<IMatchQueryRepository>()
                .Should()
                .NotBeNull();
        }
    }
}
