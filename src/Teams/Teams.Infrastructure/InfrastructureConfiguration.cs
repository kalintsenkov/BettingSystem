namespace BettingSystem.Infrastructure.Teams
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
                .AddCommonInfrastructure<TeamsDbContext>(
                    configuration,
                    Assembly.GetExecutingAssembly())
                .AddTransient<IDbInitializer, TeamsDbInitializer>();
    }
}
