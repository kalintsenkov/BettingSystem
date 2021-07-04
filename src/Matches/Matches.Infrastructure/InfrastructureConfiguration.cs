namespace BettingSystem.Infrastructure.Matches
{
    using System;
    using System.Reflection;
    using Application.Matches.Teams.Consumers;
    using Common;
    using Common.Persistence;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Persistence;

    public static class InfrastructureConfiguration
    {
        private static readonly Type[] Consumers =
        {
            typeof(TeamCreatedEventConsumer),
            typeof(TeamUpdatedEventConsumer)
        };

        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddEvents(
                    configuration,
                    usePolling: false,
                    consumers: Consumers)
                .AddCommonInfrastructure<MatchesDbContext>(
                    configuration,
                    Assembly.GetExecutingAssembly())
                .AddTransient<IDbInitializer, MatchesDbInitializer>();
    }
}
