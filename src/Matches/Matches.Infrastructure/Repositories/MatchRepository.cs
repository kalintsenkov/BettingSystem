namespace BettingSystem.Infrastructure.Matches.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Matches;
    using Application.Matches.Queries.Common;
    using Application.Matches.Queries.Details;
    using Application.Matches.Queries.Stadiums;
    using AutoMapper;
    using Common.Repositories;
    using Domain.Common;
    using Domain.Matches.Models;
    using Domain.Matches.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Persistence;

    internal class MatchRepository : DataRepository<MatchesDbContext, Match>,
        IMatchDomainRepository,
        IMatchQueryRepository
    {
        private readonly IMapper mapper;

        public MatchRepository(MatchesDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<bool> Delete(
            int id,
            CancellationToken cancellationToken = default)
        {
            var match = await this.Data.Matches.FindAsync(id);

            if (match == null)
            {
                return false;
            }

            this.Data.Matches.Remove(match);

            await this.Data.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<Match> Find(
            int id,
            CancellationToken cancellationToken = default)
            => await this
                .All()
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .Include(m => m.Stadium)
                .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);

        public async Task<IEnumerable<MatchResponseModel>> GetMatchListings(
            Specification<Match> matchSpecification,
            CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<MatchResponseModel>(this
                    .AllAsNoTracking()
                    .Where(matchSpecification))
                .ToListAsync(cancellationToken);

        public async Task<MatchDetailsResponseModel> GetDetails(
            int id,
            CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<MatchDetailsResponseModel>(this
                    .AllAsNoTracking()
                    .Where(m => m.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<Team> GetTeam(
            string team,
            CancellationToken cancellationToken = default)
            => await this
                .AllTeams()
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Name == team, cancellationToken);

        public async Task<Team> GetTeam(
            int teamId, 
            CancellationToken cancellationToken = default)
            => await this
                .AllTeams()
                .FirstOrDefaultAsync(t => t.Id == teamId, cancellationToken);

        public async Task SaveTeam(
            Team team, 
            CancellationToken cancellationToken = default)
        {
            await this.Data.Teams.AddAsync(team, cancellationToken);
            await this.Data.SaveChangesAsync(cancellationToken);
        }

        public async Task<Stadium> GetStadium(
            string stadium,
            CancellationToken cancellationToken = default)
            => await this
                .AllStadiums()
                .FirstOrDefaultAsync(s => s.Name == stadium, cancellationToken);

        public async Task<IEnumerable<GetMatchStadiumsResponseModel>> GetStadiums(
            CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<GetMatchStadiumsResponseModel>(this
                    .AllStadiums())
                .ToListAsync(cancellationToken);

        private IQueryable<Team> AllTeams()
            => this
                .Data
                .Teams;

        private IQueryable<Stadium> AllStadiums()
            => this
                .Data
                .Stadiums
                .AsNoTracking();
    }
}
