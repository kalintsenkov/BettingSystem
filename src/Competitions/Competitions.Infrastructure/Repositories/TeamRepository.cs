﻿namespace BettingSystem.Infrastructure.Competitions.Repositories
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Competitions.Teams;
    using Common.Persistence;
    using Domain.Competitions.Models.Teams;
    using Domain.Competitions.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Persistence;

    internal class TeamRepository : DataRepository<ICompetitionsDbContext, Team>,
        ITeamDomainRepository,
        ITeamQueryRepository
    {
        public TeamRepository(ICompetitionsDbContext db)
            : base(db)
        {
        }

        public async Task<Team> Find(
            int id,
            CancellationToken cancellationToken = default)
            => await this
                .All()
                .Where(t => t.Id == id)
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