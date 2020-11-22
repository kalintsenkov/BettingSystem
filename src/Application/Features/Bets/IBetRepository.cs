namespace BettingSystem.Application.Features.Bets
{
    using System.Threading;
    using System.Threading.Tasks;
    using Contracts;
    using Domain.Models.Bets;
    using Queries.Details;

    public interface IBetRepository : IRepository<Bet>
    {
        Task<BetDetailsResponseModel> GetDetails(
            int id,
            CancellationToken cancellationToken = default);
    }
}