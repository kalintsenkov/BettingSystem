namespace BettingSystem.Watchdog;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
        => services
            .AddHealthChecksUI()
            .AddInMemoryStorage();

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        => app
            .UseRouting()
            .UseEndpoints(endpoints => endpoints
                .MapHealthChecksUI(healthChecks => healthChecks
                    .UIPath = "/health"));
}