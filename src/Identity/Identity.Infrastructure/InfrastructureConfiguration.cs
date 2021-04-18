namespace BettingSystem.Infrastructure.Identity
{
    using System.Reflection;
    using Application.Identity;
    using Common;
    using Common.Persistence;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Persistence;
    using Services;

    using static Domain.Common.Models.ModelConstants.Identity;

    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddIdentity()
                .AddCommonInfrastructure<IdentityDbContext>(
                    configuration,
                    Assembly.GetExecutingAssembly())
                .AddTransient<IDbInitializer, IdentityDbInitializer>();

        internal static IServiceCollection AddIdentity(
            this IServiceCollection services)
        {
            services
                .AddTransient<IIdentity, IdentityService>()
                .AddTransient<IJwtGenerator, JwtGeneratorService>()
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = MinPasswordLength;
                })
                .AddEntityFrameworkStores<IdentityDbContext>();

            return services;
        }
    }
}
