﻿namespace BettingSystem.Application.Matches
{
    using System.Reflection;
    using Common.Configuration;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services,
            IConfiguration configuration)
            => services.AddCommonApplication(
                configuration,
                Assembly.GetExecutingAssembly());
    }
}