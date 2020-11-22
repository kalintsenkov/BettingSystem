namespace BettingSystem.Infrastructure
{
    using System;
    using System.Reflection;
    using Application.Features.Bets;
    using Application.Features.Gamblers;
    using Application.Features.Matches;
    using AutoMapper;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Persistence;
    using Xunit;

    public class InfrastructureConfigurationSpecs
    {
        [Fact]
        public void AddRepositoriesShouldRegisterRepositories()
        {
            // Arrange
            var serviceCollection = new ServiceCollection()
                .AddDbContext<BettingDbContext>(options => options
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()));

            // Act
            var services = serviceCollection
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddRepositories()
                .BuildServiceProvider();

            // Assert
            services
                .GetService<IGamblerRepository>()
                .Should()
                .NotBeNull();

            services
                .GetService<IMatchRepository>()
                .Should()
                .NotBeNull();

            services
                .GetService<IBetRepository>()
                .Should()
                .NotBeNull();
        }
    }
}
