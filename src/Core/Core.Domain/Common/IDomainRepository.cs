namespace BettingSystem.Domain.Common
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IDomainRepository<TEntity>
        where TEntity : IAggregateRoot
    {
        Task<TEntity> Save(
            TEntity entity,
            CancellationToken cancellationToken = default);
    }
}