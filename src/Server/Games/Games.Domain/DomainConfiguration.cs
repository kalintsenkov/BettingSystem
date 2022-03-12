﻿namespace BettingSystem.Domain.Games;

using System.Reflection;
using Common;
using Microsoft.Extensions.DependencyInjection;

public static class DomainConfiguration
{
    public static IServiceCollection AddDomain(
        this IServiceCollection services)
        => services
            .AddCommonDomain(
                Assembly.GetExecutingAssembly());
}