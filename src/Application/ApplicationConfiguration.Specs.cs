namespace BettingSystem.Application
{
    using AutoMapper;
    using FluentAssertions;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class ApplicationConfigurationSpecs
    {
        [Fact]
        public void AddApplicationShouldConfigureApplicationSettings()
        {
            // Arrange
            var configuration = ApplicationConfigurationFakes.FakeConfiguration;
            var serviceCollection = new ServiceCollection();

            // Act
            serviceCollection.AddApplication(configuration);

            var secret = configuration["ApplicationSettings:Secret"];

            // Assert
            secret.Should().NotBeNullOrEmpty();
            secret.Should().Be(ApplicationConfigurationFakes.FakeSecret);
        }

        [Fact]
        public void AddApplicationShouldRegisterAutoMapper()
        {
            // Arrange
            var configuration = ApplicationConfigurationFakes.FakeConfiguration;
            var serviceCollection = new ServiceCollection();

            // Act
            var services = serviceCollection
                .AddApplication(configuration)
                .BuildServiceProvider();

            // Assert
            services
                .GetService<IMapper>()
                .Should()
                .NotBeNull();
        }

        [Fact]
        public void AddApplicationShouldRegisterMediator()
        {
            // Arrange
            var configuration = ApplicationConfigurationFakes.FakeConfiguration;
            var serviceCollection = new ServiceCollection();

            // Act
            var services = serviceCollection
                .AddApplication(configuration)
                .BuildServiceProvider();

            // Assert
            services
                .GetService<IMediator>()
                .Should()
                .NotBeNull();
        }
    }
}
