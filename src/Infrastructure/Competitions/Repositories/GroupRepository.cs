namespace BettingSystem.Infrastructure.Competitions.Repositories
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Competitions.Groups;
    using AutoMapper;
    using Common.Persistence.Models;
    using Common.Persistence.Repositories;
    using Domain.Competitions.Models.Groups;
    using Domain.Competitions.Repositories;
    using Microsoft.EntityFrameworkCore;

    internal class GroupRepository : DataRepository<ITournamentsDbContext, Group, GroupData>,
        IGroupDomainRepository,
        IGroupQueryRepository
    {
        public GroupRepository(ITournamentsDbContext db, IMapper mapper)
            : base(db, mapper)
        {
        }

        public async Task<bool> Delete(
            int id,
            CancellationToken cancellationToken = default)
        {
            var group = await this.Data.Groups.FindAsync(id);

            if (group == null)
            {
                return false;
            }

            this.Data.Groups.Remove(group);

            await this.Data.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<Group> Find(
            int id,
            CancellationToken cancellationToken = default)
            => await this.Mapper
                .ProjectTo<Group>(this
                    .AllAsDataModels()
                    .Where(t => t.Id == id))
                .FirstOrDefaultAsync(cancellationToken);
    }
}
