namespace BettingSystem.Domain.Competitions
{
    using System.Reflection;
    using Common.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class DomainConfiguration
    {
        public static IServiceCollection AddDomain(
            this IServiceCollection services)
            => services.AddCommonDomain(
                Assembly.GetExecutingAssembly());
    }
}
