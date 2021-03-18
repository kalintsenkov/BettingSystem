namespace BettingSystem.Infrastructure.Competitions
{
    using System.Reflection;
    using Common;
    using Common.Configuration;
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
                .AddTransient<IInitializer, CompetitionsDbInitializer>();
    }
}
