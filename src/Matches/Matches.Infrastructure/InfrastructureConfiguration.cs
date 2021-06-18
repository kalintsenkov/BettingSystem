namespace BettingSystem.Infrastructure.Matches
{
    using System.Reflection;
    using Application.Matches.Consumers;
    using Common;
    using Common.Persistence;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Persistence;

    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddEvents(
                    configuration,
                    usePolling: false,
                    consumers: typeof(TeamUpdatedEventConsumer))
                .AddCommonInfrastructure<MatchesDbContext>(
                    configuration,
                    Assembly.GetExecutingAssembly())
                .AddTransient<IDbInitializer, MatchesDbInitializer>();
    }
}
