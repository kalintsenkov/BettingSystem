namespace BettingSystem.Startup.Identity;

using Application.Identity;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web.Common.Extensions;
using Web.Identity;

public class Startup
{
    public Startup(IConfiguration configuration)
        => this.Configuration = configuration;

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
        => services
            .AddApplication(this.Configuration)
            .AddInfrastructure(this.Configuration)
            .AddWebComponents();

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        => app
            .UseWebService(env)
            .Initialize();
}