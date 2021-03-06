namespace BettingSystem.Infrastructure
{
    using System.Text;
    using Application.Common;
    using Betting;
    using Common;
    using Common.Configuration;
    using Competitions;
    using Matches;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using Persistence;
    using Teams;

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
                .AddDbContext<BettingDbContext>(options => options
                    .UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        sqlServer => sqlServer.MigrationsAssembly(
                            typeof(BettingDbContext).Assembly.FullName)))
                .AddScoped<IBettingDbContext>(provider => provider
                    .GetService<BettingDbContext>()!)
                .AddScoped<IMatchesDbContext>(provider => provider
                    .GetService<BettingDbContext>()!)
                .AddScoped<ITeamsDbContext>(provider => provider
                    .GetService<BettingDbContext>()!)
                .AddScoped<ICompetitionsDbContext>(provider => provider
                    .GetService<BettingDbContext>()!)
                .AddTransient<IInitializer, BettingDbInitializer>();
    }
}
