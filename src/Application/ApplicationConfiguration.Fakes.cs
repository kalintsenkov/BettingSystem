namespace BettingSystem.Application
{
    using FakeItEasy;
    using Microsoft.Extensions.Configuration;

    public class ApplicationConfigurationFakes
    {
        public const string FakeSecret = "My Fake Secret";

        public static IConfiguration FakeConfiguration
        {
            get
            {
                var configuration = A.Fake<IConfiguration>();

                A
                    .CallTo(() => configuration["ApplicationSettings:Secret"])
                    .Returns(FakeSecret);

                return configuration;
            }
        }
    }
}
