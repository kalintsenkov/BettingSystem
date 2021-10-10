namespace BettingSystem.Domain.Competitions.Repositories
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Models.Leagues;

    public interface ILeagueDomainRepository : IDomainRepository<League>
    {
        Task<bool> Delete(
            int id,
            CancellationToken cancellationToken = default);

        Task<League?> Find(
            int id,
            CancellationToken cancellationToken = default);

        Task<Country?> GetCountry(
            string country,
            CancellationToken cancellationToken = default);
    }
}
