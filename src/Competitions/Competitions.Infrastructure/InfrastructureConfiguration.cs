namespace BettingSystem.Infrastructure.Competitions
{
    using System.Reflection;
    using Application.Competitions.Teams.Consumers;
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
                .AddEvents(typeof(MatchFinishedEventConsumer))
                .AddCommonInfrastructure<CompetitionsDbContext>(
                    configuration,
                    Assembly.GetExecutingAssembly())
                .AddTransient<IDbInitializer, CompetitionsDbInitializer>();
    }
}
