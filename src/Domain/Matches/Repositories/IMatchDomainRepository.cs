namespace BettingSystem.Domain.Matches.Repositories
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Models;

    public interface IMatchDomainRepository : IDomainRepository<Match>
    {
        Task<bool> Delete(
            int id,
            CancellationToken cancellationToken = default);

        Task<Match> Find(
            int id,
            CancellationToken cancellationToken = default);

        Task<Team> GetTeam(
            string team,
            CancellationToken cancellationToken = default);

        Task<Stadium> GetStadium(
            string stadium,
            CancellationToken cancellationToken = default);
    }
}
