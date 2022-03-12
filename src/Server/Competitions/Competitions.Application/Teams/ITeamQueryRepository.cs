namespace BettingSystem.Application.Competitions.Teams;

using System.Threading;
using System.Threading.Tasks;
using Common.Contracts;
using Domain.Competitions.Models.Teams;
using Queries.Details;

public interface ITeamQueryRepository : IQueryRepository<Team>
{
    Task<TeamDetailsResponseModel?> GetDetails(
        int id,
        CancellationToken cancellationToken = default);
}