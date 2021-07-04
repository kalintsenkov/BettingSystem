namespace BettingSystem.Infrastructure.Identity.Services
{
    using System.Threading.Tasks;

    public interface IJwtGenerator
    {
        Task<string> GenerateToken(User user);
    }
}
