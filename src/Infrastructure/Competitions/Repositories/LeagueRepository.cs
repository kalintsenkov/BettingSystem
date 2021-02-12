namespace BettingSystem.Infrastructure.Competitions.Repositories
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Competitions.Leagues;
    using AutoMapper;
    using Common.Persistence.Models;
    using Common.Persistence.Repositories;
    using Domain.Competitions.Models.Leagues;
    using Domain.Competitions.Repositories;
    using Microsoft.EntityFrameworkCore;

    internal class LeagueRepository : DataRepository<ICompetitionsDbContext, League, LeagueData>,
        ILeagueDomainRepository,
        ILeagueQueryRepository
    {
        public LeagueRepository(ICompetitionsDbContext db, IMapper mapper)
            : base(db, mapper)
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
                    .Where(t => t.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

        public async Task GiveTeamPoints(
            int homeTeamId,
            int awayTeamId,
            int homeScore,
            int awayScore,
            CancellationToken cancellationToken = default)
        {
            var homeTeam = await this.GetTeam(
                homeTeamId,
                cancellationToken);

            var awayTeam = await this.GetTeam(
                awayTeamId,
                cancellationToken);

            if (homeScore > awayScore)
            {
                homeTeam.GivePointsForWin();
            }
            else if (homeScore < awayScore)
            {
                awayTeam.GivePointsForWin();
            }
            else if (homeScore == awayScore)
            {
                homeTeam.GivePointFromDraw();
                awayTeam.GivePointFromDraw();
            }

            await this.Save(homeTeam.League, cancellationToken);
        }

        private async Task<Team> GetTeam(
            int id,
            CancellationToken cancellationToken = default)
            => await this.Mapper
                .ProjectTo<Team>(this
                    .Data
                    .Teams
                    .Where(t => t.Id == id))
                .FirstOrDefaultAsync(cancellationToken);
    }
}
