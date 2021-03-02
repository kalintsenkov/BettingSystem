namespace BettingSystem.Infrastructure.Competitions.Repositories
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Competitions.Teams;
    using AutoMapper;
    using Common.Events;
    using Common.Persistence;
    using Domain.Competitions.Models.Leagues;
    using Domain.Competitions.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Persistence.Models;

    internal class TeamRepository : DataRepository<ICompetitionsDbContext, Team, TeamData>,
        ITeamDomainRepository,
        ITeamQueryRepository
    {
        public TeamRepository(
            ICompetitionsDbContext db,
            IMapper mapper,
            IEventDispatcher eventDispatcher)
            : base(db, mapper, eventDispatcher)
        {
        }

        public async Task<Team> Find(
            int id,
            CancellationToken cancellationToken = default)
            => await this.Mapper
                .ProjectTo<Team>(this
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
            var homeTeam = await this.Find(
                homeTeamId,
                cancellationToken);

            var awayTeam = await this.Find(
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

            await this.Save(homeTeam, cancellationToken);
            await this.Save(awayTeam, cancellationToken);
        }
    }
}
