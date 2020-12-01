namespace BettingSystem.Infrastructure.Betting.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Betting.Matches;
    using Application.Betting.Matches.Queries.Common;
    using Application.Betting.Matches.Queries.Details;
    using Application.Betting.Matches.Queries.Stadiums;
    using Application.Betting.Matches.Queries.Teams;
    using AutoMapper;
    using Common.Persistence;
    using Common.Persistence.Repositories;
    using Domain.Betting.Models.Matches;
    using Domain.Betting.Repositories;
    using Domain.Common;
    using Microsoft.EntityFrameworkCore;

    internal class MatchRepository : DataRepository<IBettingDbContext, Match>,
        IMatchDomainRepository,
        IMatchQueryRepository
    {
        private readonly IMapper mapper;

        public MatchRepository(BettingDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<bool> Delete(
            int id,
            CancellationToken cancellationToken = default)
        {
            var match = await this.Data.Matches.FindAsync(id, cancellationToken);

            if (match == null)
            {
                return false;
            }

            this.Data.Remove(match);

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

        public async Task<Team> GetHomeTeam(
            string homeTeam,
            CancellationToken cancellationToken = default)
            => await this
                .AllTeams()
                .FirstOrDefaultAsync(t => t.Name == homeTeam, cancellationToken);

        public async Task<Team> GetAwayTeam(
            string awayTeam,
            CancellationToken cancellationToken = default)
            => await this
                .AllTeams()
                .FirstOrDefaultAsync(t => t.Name == awayTeam, cancellationToken);

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

        public async Task<IEnumerable<GetMatchTeamsResponseModel>> GetTeams(
            CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<GetMatchTeamsResponseModel>(this
                    .AllTeams())
                .ToListAsync(cancellationToken);

        private IQueryable<Team> AllTeams()
            => this
                .Data
                .Teams
                .AsNoTracking();

        private IQueryable<Stadium> AllStadiums()
            => this
                .Data
                .Stadiums
                .AsNoTracking();
    }
}
