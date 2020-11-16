namespace BettingSystem.Domain
{
    using Factories;
    using Factories.Matches;
    using Microsoft.Extensions.DependencyInjection;

    public static class DomainConfiguration
    {
        public static IServiceCollection AddDomain(
            this IServiceCollection services)
            => services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IFactory<>)))
                    .AsMatchingInterface()
                    .WithTransientLifetime())
                .AddTransient<IMatchFactory, MachFactory>();
    }
}
