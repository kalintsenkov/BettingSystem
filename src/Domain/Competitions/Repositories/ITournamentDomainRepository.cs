namespace BettingSystem.Domain.Competitions.Repositories
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Models.Matches;
    using Models.Tournaments;

    public interface ITournamentDomainRepository : IDomainRepository<Tournament>
    {
        Task<bool> Delete(
            int id,
            CancellationToken cancellationToken = default);

        Task<Tournament> Find(
            int id,
            CancellationToken cancellationToken = default);

        Task<Match> FindMatch(
            int matchId,
            CancellationToken cancellationToken = default);
    }
}
