namespace BettingSystem.Infrastructure.Teams
{
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
                .AddCommonInfrastructure(configuration)
                .AddDatabase(configuration);

        private static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDbContext<TeamsDbContext>(options => options
                    .UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        sqlServer => sqlServer.MigrationsAssembly(
                            typeof(TeamsDbContext).Assembly.FullName)))
                .AddScoped<ITeamsDbContext>(provider => provider
                    .GetService<TeamsDbContext>()!)
                .AddTransient<IInitializer, TeamsDbInitializer>();
    }
}
