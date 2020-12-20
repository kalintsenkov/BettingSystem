namespace BettingSystem.Application.Teams
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Contracts;
    using Domain.Teams.Models;
    using Queries.All;

    public interface ITeamQueryRepository : IQueryRepository<Team>
    {
        Task<IEnumerable<GetAllTeamsResponseModel>> GetTeamListings(
            CancellationToken cancellationToken = default);
    }
}