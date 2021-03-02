namespace BettingSystem.Infrastructure.Common.Configuration
{
    using System.Reflection;
    using Application.Common.Contracts;
    using Domain.Common;
    using Events;
    using Microsoft.Extensions.DependencyInjection;
    using Services;

    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddCommonInfrastructure(
            this IServiceCollection services)
            => services
                .AddRepositories()
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddTransient<IEventDispatcher, EventDispatcher>()
                .AddTransient<IImageService, ImageService>();

        internal static IServiceCollection AddRepositories(
            this IServiceCollection services)
            => services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IDomainRepository<>))
                        .AssignableTo(typeof(IQueryRepository<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());
    }
}
