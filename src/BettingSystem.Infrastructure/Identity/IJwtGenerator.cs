namespace BettingSystem.Infrastructure.Identity
{
    public interface IJwtGenerator
    {
        string GenerateToken(User user);
    }
}
