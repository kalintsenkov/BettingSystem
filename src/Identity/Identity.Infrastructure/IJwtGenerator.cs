namespace BettingSystem.Infrastructure.Identity
{
    using System.Threading.Tasks;

    public interface IJwtGenerator
    {
        Task<string> GenerateToken(User user);
    }
}
