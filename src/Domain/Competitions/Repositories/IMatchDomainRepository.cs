namespace BettingSystem.Domain.Competitions.Repositories
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Models.Matches;

    public interface IMatchDomainRepository : IDomainRepository<Match>
    {
        Task<bool> Delete(
            int id,
            CancellationToken cancellationToken = default);

        Task<Match> Find(
            int id,
            CancellationToken cancellationToken = default);

        Task<Team> GetHomeTeam(
            string homeTeam,
            CancellationToken cancellationToken = default);

        Task<Team> GetAwayTeam(
            string awayTeam,
            CancellationToken cancellationToken = default);

        Task<Stadium> GetStadium(
            string stadium,
            CancellationToken cancellationToken = default);
    }
}
