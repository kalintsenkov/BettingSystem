namespace BettingSystem.Application.Features.Bets
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Contracts;
    using Domain.Models.Bets;
    using Queries.Details;
    using Queries.Mine;

    public interface IBetRepository : IRepository<Bet>
    {
        Task<bool> Delete(
            int id,
            CancellationToken cancellationToken = default);

        Task<Bet> Find(
            int id,
            CancellationToken cancellationToken = default);

        Task<BetDetailsResponseModel> GetDetails(
            int id,
            CancellationToken cancellationToken = default);

        Task<IEnumerable<MineBetsResponseModel>> GetMine(
            int gamblerId,
            CancellationToken cancellationToken = default);
    }
}