namespace BettingSystem.Web
{
    using Application.Common;
    using Application.Common.Contracts;
    using Common.ModelBinders;
    using Common.Services;
    using FluentValidation.AspNetCore;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    public static class WebConfiguration
    {
        public static IServiceCollection AddWebComponents(
            this IServiceCollection services)
        {
            services
                .AddScoped<ICurrentUser, CurrentUserService>()
                .AddControllers(options => options
                    .ModelBinderProviders
                    .Insert(0, new ImageModelBinderProvider()))
                .AddFluentValidation(validation => validation
                    .RegisterValidatorsFromAssemblyContaining<Result>())
                .AddNewtonsoftJson();

            services
                .Configure<ApiBehaviorOptions>(options => options
                    .SuppressModelStateInvalidFilter = true);

            return services;
        }
    }
}
