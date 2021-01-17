namespace BettingSystem.Domain.Competitions.Repositories
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Models.Groups;

    public interface IGroupDomainRepository : IDomainRepository<Group>
    {
        Task<bool> Delete(
            int id,
            CancellationToken cancellationToken = default);

        Task<Group> Find(
            int id,
            CancellationToken cancellationToken = default);
    }
}
