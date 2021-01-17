namespace BettingSystem.Infrastructure.Championships.Repositories
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Championships.Tournaments;
    using AutoMapper;
    using Common.Persistence.Models;
    using Common.Persistence.Repositories;
    using Domain.Championships.Models.Matches;
    using Domain.Championships.Models.Tournaments;
    using Domain.Championships.Repositories;
    using Microsoft.EntityFrameworkCore;

    internal class TournamentRepository : DataRepository<ITournamentsDbContext, Tournament, TournamentData>,
        ITournamentDomainRepository,
        ITournamentQueryRepository
    {
        public TournamentRepository(ITournamentsDbContext db, IMapper mapper)
            : base(db, mapper)
        {
        }

        public async Task<bool> Delete(
            int id,
            CancellationToken cancellationToken = default)
        {
            var tournament = await this.Data.Tournaments.FindAsync(id);

            if (tournament == null)
            {
                return false;
            }

            this.Data.Tournaments.Remove(tournament);

            await this.Data.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<Tournament> Find(
            int id,
            CancellationToken cancellationToken = default)
            => await this.Mapper
                .ProjectTo<Tournament>(this
                    .AllAsDataModels()
                    .Where(t => t.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<Match> FindMatch(
            int matchId,
            CancellationToken cancellationToken = default)
            => await this.Mapper
                .ProjectTo<Match>(this
                    .Data
                    .Matches
                    .AsNoTracking()
                    .Where(t => t.Id == matchId))
                .FirstOrDefaultAsync(cancellationToken);
    }
}
