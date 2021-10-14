namespace BettingSystem.Application.Teams
{
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
        Task<IEnumerable<GetAllTeamsResponseModel>> GetTeamListings(
            CancellationToken cancellationToken = default);

        Task<IEnumerable<GetAllCoachesResponseModel>> GetCoaches(
            CancellationToken cancellationToken = default);

        Task<IEnumerable<GetTeamPlayersResponseModel>> GetTeamPlayers(
            int teamId,
            CancellationToken cancellationToken = default);
    }
}