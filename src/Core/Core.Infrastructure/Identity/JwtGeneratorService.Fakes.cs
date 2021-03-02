namespace BettingSystem.Infrastructure.Identity
{
    using FakeItEasy;

    public class JwtGeneratorFakes
    {
        public const string ValidToken = "ValidToken";

        public static IJwtGenerator FakeJwtTokenGenerator
        {
            get
            {
                var jwtGenerator = A.Fake<IJwtGenerator>();

                A
                    .CallTo(() => jwtGenerator.GenerateToken(A<User>.Ignored))
                    .Returns(ValidToken);

                return jwtGenerator;
            }
        }
    }
}