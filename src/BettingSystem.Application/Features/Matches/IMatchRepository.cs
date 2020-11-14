namespace BettingSystem.Application.Features.Matches
{
    using System.Threading;
    using System.Threading.Tasks;
    using Contracts;
    using Domain.Models.Matches;
    using Queries.Details;

    public interface IMatchRepository : IRepository<Match>
    {
        Task<MatchDetailsResponseModel> GetDetails(
            int id,
            CancellationToken cancellationToken = default);
    }
}