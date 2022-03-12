namespace BettingSystem.Domain.Competitions.Repositories;

using System.Threading;
using System.Threading.Tasks;
using Common;
using Models.Teams;

public interface ITeamDomainRepository : IDomainRepository<Team>
{
    Task<Team?> Find(
        int id,
        CancellationToken cancellationToken = default);
}