namespace BettingSystem.Web.Matches
{
    using Common.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class WebConfiguration
    {
        public static IServiceCollection AddWebComponents(
            this IServiceCollection services)
            => services.AddCommonWebComponents();
    }
}
