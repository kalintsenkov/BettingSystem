namespace BettingSystem.Infrastructure.Competitions.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Competitions.Leagues;
    using Application.Competitions.Leagues.Queries.Standings;
    using AutoMapper;
    using Common.Events;
    using Common.Persistence.Models;
    using Common.Persistence.Repositories;
    using Domain.Competitions.Models.Leagues;
    using Domain.Competitions.Repositories;
    using Microsoft.EntityFrameworkCore;

    internal class LeagueRepository : DataRepository<ICompetitionsDbContext, League, LeagueData>,
        ILeagueDomainRepository,
        ILeagueQueryRepository
    {
        public LeagueRepository(
            ICompetitionsDbContext db,
            IMapper mapper,
            IEventDispatcher eventDispatcher)
            : base(db, mapper, eventDispatcher)
        {
        }

        public async Task<bool> Delete(
            int id,
            CancellationToken cancellationToken = default)
        {
            var group = await this.Data.Leagues.FindAsync(id);

            if (group == null)
            {
                return false;
            }

            this.Data.Leagues.Remove(group);

            await this.Data.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<League> Find(
            int id,
            CancellationToken cancellationToken = default)
            => await this.Mapper
                .ProjectTo<League>(this
                    .AllAsDataModels()
                    .Where(l => l.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<IEnumerable<GetStandingsResponseModel>> GetStandings(
            int leagueId,
            CancellationToken cancellationToken = default)
            => await this.Mapper
                .ProjectTo<GetStandingsResponseModel>(this
                    .AllAsDataModels()
                    .Where(l => l.Id == leagueId)
                    .SelectMany(l => l.Teams)
                    .OrderByDescending(t => t.Points))
                .ToListAsync(cancellationToken);
    }
}
