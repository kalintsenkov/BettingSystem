namespace BettingSystem.Application.Games.Teams;

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Common.Contracts;
using Domain.Games.Models.Teams;

public interface ITeamQueryRepository : IQueryRepository<Team>
{
    Task<Stream> GetThumbnailLogo(
        int teamId,
        CancellationToken cancellationToken = default);

    Task<Stream> GetOriginalLogo(
        int teamId,
        CancellationToken cancellationToken = default);
}