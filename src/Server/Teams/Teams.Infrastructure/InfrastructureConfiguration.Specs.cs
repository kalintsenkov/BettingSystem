namespace BettingSystem.Infrastructure.Teams;

using System;
using System.Reflection;
using Application.Teams;
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
            .AddDbContext<TeamsDbContext>(options => options
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
            .GetService<ITeamQueryRepository>()
            .Should()
            .NotBeNull();
    }
}