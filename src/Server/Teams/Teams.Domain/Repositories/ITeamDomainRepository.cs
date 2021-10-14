namespace BettingSystem.Domain.Teams.Repositories
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Models;

    public interface ITeamDomainRepository : IDomainRepository<Team>
    {
        Task<bool> Delete(
            int id,
            CancellationToken cancellationToken = default);

        Task<Team?> Find(
            int id,
            CancellationToken cancellationToken = default);

        Task<Coach?> GetCoach(
            string name,
            CancellationToken cancellationToken = default);
    }
}
