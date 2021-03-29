namespace BettingSystem.Infrastructure.Common.Repositories
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Common;
    using Microsoft.EntityFrameworkCore;
    using Persistence;

    internal abstract class DataRepository<TDbContext, TEntity> : IDomainRepository<TEntity>
        where TDbContext : IDbContext
        where TEntity : class, IAggregateRoot
    {
        protected DataRepository(TDbContext db) => this.Data = db;

        protected TDbContext Data { get; }

        protected IQueryable<TEntity> All() => this.Data.Set<TEntity>();

        protected IQueryable<TEntity> AllAsNoTracking() => this.All().AsNoTracking();

        public async Task<TEntity> Save(
            TEntity entity,
            CancellationToken cancellationToken = default)
        {
            this.Data.Update(entity);

            await this.Data.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}
