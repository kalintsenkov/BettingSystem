namespace BettingSystem.Web.Common;

using System;
using Application.Common.Contracts;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ModelBinders;
using Services;

public static class WebConfiguration
{
    public static IServiceCollection AddCommonWebComponents(
        this IServiceCollection services,
        Type applicationConfigurationType)
    {
        services
            .AddScoped<ICurrentUser, CurrentUserService>()
            .AddControllers(options => options
                .ModelBinderProviders
                .Insert(0, new ImageModelBinderProvider()))
            .AddFluentValidation(validation => validation
                .RegisterValidatorsFromAssemblyContaining(applicationConfigurationType))
            .AddNewtonsoftJson();

        services
            .Configure<ApiBehaviorOptions>(options => options
                .SuppressModelStateInvalidFilter = true);

        return services;
    }
}