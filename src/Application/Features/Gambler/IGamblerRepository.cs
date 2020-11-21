namespace BettingSystem.Application.Features.Gambler
{
    using System.Threading;
    using System.Threading.Tasks;
    using Contracts;
    using Domain.Models.Gamblers;

    public interface IGamblerRepository : IRepository<Gambler>
    {
        Task<Gambler> FindByUser(
            string userId,
            CancellationToken cancellationToken = default);

        Task<int> GetGamblerId(
            string userId,
            CancellationToken cancellationToken = default);
    }
}
