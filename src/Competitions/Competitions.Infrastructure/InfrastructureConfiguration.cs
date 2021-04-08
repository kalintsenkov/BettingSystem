namespace BettingSystem.Infrastructure.Competitions
{
    using System.Reflection;
    using Application.Competitions.Teams.Handlers;
    using Common;
    using Common.Persistence;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Persistence;

    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDatabase(configuration)
                .AddEvents(typeof(MatchFinishedEventConsumer))
                .AddCommonInfrastructure(
                    configuration,
                    Assembly.GetExecutingAssembly());

        private static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDbContext<CompetitionsDbContext>(options => options
                    .UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        sqlServer => sqlServer.MigrationsAssembly(
                            typeof(CompetitionsDbContext).Assembly.FullName)))
                .AddScoped<ICompetitionsDbContext>(provider => provider
                    .GetService<CompetitionsDbContext>()!)
                .AddTransient<IDbInitializer, CompetitionsDbInitializer>();
    }
}
