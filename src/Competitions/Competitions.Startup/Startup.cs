namespace BettingSystem.Startup.Competitions
{
    using Application.Competitions;
    using Domain.Competitions;
    using Infrastructure.Competitions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Web.Common.Extensions;
    using Web.Common.Middleware;
    using Web.Competitions;

    public class Startup
    {
        public Startup(IConfiguration configuration)
            => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddDomain()
                .AddApplication(this.Configuration)
                .AddInfrastructure(this.Configuration)
                .AddWebComponents();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseExceptionHandling(env)
                .UseValidationExceptionHandler()
                .UseHttpsRedirection()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints
                    .MapControllers())
                .Initialize();
    }
}
