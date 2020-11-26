namespace BettingSystem.Application.Features.Bets
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Contracts;
    using Domain.Models.Bets;
    using Domain.Models.Gamblers;
    using Domain.Specifications;
    using Queries.Details;

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

        Task<IEnumerable<TResponseModel>> GetBetListings<TResponseModel>(
            Specification<Bet> betSpecification,
            Specification<Gambler> gamblerSpecification,
            CancellationToken cancellationToken = default);
    }
}