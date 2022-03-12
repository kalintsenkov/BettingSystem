namespace BettingSystem.Application.Teams;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Contracts;
using Domain.Teams.Models;
using Queries.All;
using Queries.Coaches;
using Queries.Players;

public interface ITeamQueryRepository : IQueryRepository<Team>
{
    Task<IEnumerable<GetAllTeamsResponseModel>> GetTeamsListing(
        CancellationToken cancellationToken = default);

    Task<IEnumerable<GetCoachesResponseModel>> GetCoachesListing(
        CancellationToken cancellationToken = default);

    Task<IEnumerable<GetTeamPlayersResponseModel>> GetTeamPlayersListing(
        int teamId,
        CancellationToken cancellationToken = default);
}