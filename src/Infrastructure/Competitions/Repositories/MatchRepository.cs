namespace BettingSystem.Infrastructure.Competitions.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Competitions.Matches;
    using Application.Competitions.Matches.Queries.Common;
    using Application.Competitions.Matches.Queries.Details;
    using Application.Competitions.Matches.Queries.Stadiums;
    using AutoMapper;
    using Common.Persistence.Models;
    using Common.Persistence.Repositories;
    using Domain.Common;
    using Domain.Competitions.Models.Matches;
    using Domain.Competitions.Repositories;
    using Microsoft.EntityFrameworkCore;

    internal class MatchRepository : DataRepository<ICompetitionsDbContext, Match, MatchData>,
        IMatchDomainRepository,
        IMatchQueryRepository
    {
        public MatchRepository(ICompetitionsDbContext db, IMapper mapper)
            : base(db, mapper)
        {
        }

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
            => await this.Mapper
                .ProjectTo<Match>(this
                    .AllAsDataModels()
                    .Include(m => m.HomeTeam)
                    .Include(m => m.AwayTeam)
                    .Include(m => m.Stadium))
                .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);

        public async Task<IEnumerable<MatchResponseModel>> GetMatchListings(
            Specification<Match> matchSpecification,
            CancellationToken cancellationToken = default)
            => await this.Mapper
                .ProjectTo<MatchResponseModel>(this
                    .AllAsDomainModels()
                    .Where(matchSpecification))
                .ToListAsync(cancellationToken);

        public async Task<MatchDetailsResponseModel> GetDetails(
            int id,
            CancellationToken cancellationToken = default)
            => await this.Mapper
                .ProjectTo<MatchDetailsResponseModel>(this
                    .AllAsDomainModels()
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
            => await this.Mapper
                .ProjectTo<GetMatchStadiumsResponseModel>(this
                    .AllStadiums())
                .ToListAsync(cancellationToken);

        private IQueryable<Team> AllTeams()
            => this.Mapper
                .ProjectTo<Team>(this
                    .Data
                    .Teams
                    .AsNoTracking());

        private IQueryable<Stadium> AllStadiums()
            => this.Mapper
                .ProjectTo<Stadium>(this
                    .Data
                    .Stadiums
                    .AsNoTracking());
    }
}
