namespace BettingSystem.Infrastructure.Identity
{
    using System.Reflection;
    using Application.Identity;
    using Common;
    using Common.Persistence;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
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
                .AddDatabase(configuration)
                .AddIdentity()
                .AddTransient<IIdentity, IdentityService>()
                .AddTransient<IJwtGenerator, JwtGeneratorService>()
                .AddCommonInfrastructure(
                    configuration,
                    Assembly.GetExecutingAssembly());

        private static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDbContext<IdentityDbContext>(options => options
                    .UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        sqlServer => sqlServer.MigrationsAssembly(
                            typeof(IdentityDbContext).Assembly.FullName)))
                .AddTransient<IDbInitializer, IdentityDbInitializer>();

        internal static IServiceCollection AddIdentity(
            this IServiceCollection services)
        {
            services
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
