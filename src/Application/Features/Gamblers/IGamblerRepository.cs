namespace BettingSystem.Application.Features.Gamblers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Contracts;
    using Domain.Models.Gamblers;
    using Queries.Details;

    public interface IGamblerRepository : IRepository<Gambler>
    {
        Task<Gambler> FindByUser(
            string userId,
            CancellationToken cancellationToken = default);

        Task<int> GetGamblerId(
            string userId,
            CancellationToken cancellationToken = default);

        Task<bool> HasBet(
            int gamblerId,
            int betId,
            CancellationToken cancellationToken = default);

        Task<GamblerDetailsResponseModel> GetDetails(
            int id,
            CancellationToken cancellationToken = default);
    }
}
