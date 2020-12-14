namespace BettingSystem.Infrastructure.Common.Persistence.Repositories
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Mapping;
    using AutoMapper;
    using Domain.Common;
    using Microsoft.EntityFrameworkCore;

    internal abstract class DataRepository<TDbContext, TEntity> : IDomainRepository<TEntity>
        where TDbContext : IDbContext
        where TEntity : class, IAggregateRoot
    {
        protected DataRepository(TDbContext db) => this.Data = db;

        protected TDbContext Data { get; }

        protected IQueryable<TEntity> All()
            => this.Data.Set<TEntity>();

        protected IQueryable<TEntity> AllAsNoTracking()
            => this.All().AsNoTracking();

        public async Task Save(
            TEntity entity,
            CancellationToken cancellationToken = default)
        {
            this.Data.Update(entity);

            await this.Data.SaveChangesAsync(cancellationToken);
        }
    }

    internal abstract class DataRepository<TDbContext, TEntity, TEntityData> : IDomainRepository<TEntity>
        where TDbContext : IDbContext
        where TEntity : class, IAggregateRoot
        where TEntityData : class, IMapTo<TEntity>, IMapFrom<TEntity>
    {
        protected DataRepository(TDbContext db, IMapper mapper)
        {
            this.Data = db;
            this.Mapper = mapper;
        }

        protected TDbContext Data { get; }

        public IMapper Mapper { get; }

        protected IQueryable<TEntity> AllAsNoTracking()
            => this.Mapper
                .ProjectTo<TEntity>(this
                    .Data
                    .Set<TEntityData>()
                    .AsNoTracking());

        public async Task Save(
            TEntity entity,
            CancellationToken cancellationToken = default)
        {
            var entityData = this.Mapper.Map<TEntityData>(entity);

            this.Data.Update(entityData);

            await this.Data.SaveChangesAsync(cancellationToken);
        }
    }
}
