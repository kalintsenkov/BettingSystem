namespace BettingSystem.Infrastructure.Matches
{
    using System.Reflection;
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
                .AddEvents()
                .AddCommonInfrastructure<MatchesDbContext>(
                    configuration,
                    Assembly.GetExecutingAssembly())
                .AddTransient<IDbInitializer, MatchesDbInitializer>();
    }
}
