﻿namespace BettingSystem.Infrastructure.Competitions.Repositories
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Competitions.Teams;
    using Application.Competitions.Teams.Queries.Details;
    using AutoMapper;
    using Common.Repositories;
    using Domain.Competitions.Models.Teams;
    using Domain.Competitions.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Persistence;

    internal class TeamRepository : DataRepository<CompetitionsDbContext, Team>,
        ITeamDomainRepository,
        ITeamQueryRepository
    {
        private readonly IMapper mapper;

        public TeamRepository(CompetitionsDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task GivePoints(
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

        public async Task<Team> Find(
            int id,
            CancellationToken cancellationToken = default)
            => await this
                .All()
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<TeamDetailsResponseModel> GetDetails(
            int id,
            CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<TeamDetailsResponseModel>(this
                    .AllAsNoTracking()
                    .Where(t => t.Id == id))
                .FirstOrDefaultAsync(cancellationToken);
    }
}
