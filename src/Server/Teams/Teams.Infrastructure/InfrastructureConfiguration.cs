namespace BettingSystem.Infrastructure.Teams
{
    using System.Reflection;
    using Application.Common.Contracts;
    using Common;
    using Common.Persistence;
    using Common.Services;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Persistence;

    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddEvents(configuration)
                .AddCommonInfrastructure<TeamsDbContext>(
                    configuration,
                    Assembly.GetExecutingAssembly())
                .AddTransient<IImageService, ImageService>()
                .AddTransient<IDbInitializer, TeamsDbInitializer>();
    }
}
