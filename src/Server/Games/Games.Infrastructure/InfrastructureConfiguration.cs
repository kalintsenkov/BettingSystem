namespace BettingSystem.Infrastructure.Games
{
    using System;
    using System.Reflection;
    using Application.Common.Contracts;
    using Application.Games.Teams.Consumers;
    using Common;
    using Common.Persistence;
    using Common.Services;
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
                    consumers: Consumers)
                .AddCommonInfrastructure<GamesDbContext>(
                    configuration,
                    Assembly.GetExecutingAssembly())
                .AddTransient<IImageService, ImageService>()
                .AddTransient<IDbInitializer, GamesDbInitializer>();
    }
}
