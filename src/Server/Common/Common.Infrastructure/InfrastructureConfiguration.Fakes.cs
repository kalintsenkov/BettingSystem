namespace BettingSystem.Infrastructure.Common;

using FakeItEasy;
using Microsoft.Extensions.Configuration;

public class InfrastructureConfigurationFakes
{
    public static IConfiguration FakeConfiguration => A.Fake<IConfiguration>();
}