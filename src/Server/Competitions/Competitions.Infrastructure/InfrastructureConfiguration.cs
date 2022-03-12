namespace BettingSystem.Infrastructure.Competitions;

using System;
using System.Reflection;
using Application.Competitions.Teams.Consumers;
using Common;
using Common.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

public static class InfrastructureConfiguration
{
    private static readonly Type[] Consumers =
    {
        typeof(MatchFinishedEventConsumer),
        typeof(TeamCreatedEventConsumer),
        typeof(TeamNameUpdatedEventConsumer)
    };

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddEvents(
                configuration,
                usePolling: false,
                consumers: Consumers)
            .AddCommonInfrastructure<CompetitionsDbContext>(
                configuration,
                Assembly.GetExecutingAssembly())
            .AddTransient<IDbInitializer, CompetitionsDbInitializer>();
}