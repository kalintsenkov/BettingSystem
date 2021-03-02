namespace BettingSystem.Domain.Betting.Repositories
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Models.Bets;
    using Models.Matches;

    public interface IBetDomainRepository : IDomainRepository<Bet>
    {
        Task<bool> Delete(
            int id,
            CancellationToken cancellationToken = default);

        Task<Bet> Find(
            int id,
            CancellationToken cancellationToken = default);

        Task<Match> GetMatch(
            int matchId,
            CancellationToken cancellationToken = default);
    }
}