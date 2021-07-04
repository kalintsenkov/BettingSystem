namespace BettingSystem.Infrastructure.Games.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Games.Matches;
    using Application.Games.Matches.Queries.Common;
    using Application.Games.Matches.Queries.Details;
    using Application.Games.Matches.Queries.Stadiums;
    using AutoMapper;
    using Common.Repositories;
    using Domain.Common;
    using Domain.Games.Models.Matches;
    using Domain.Games.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Persistence;

    internal class MatchRepository : DataRepository<GamesDbContext, Match>,
        IMatchDomainRepository,
        IMatchQueryRepository
    {
        private readonly IMapper mapper;

        public MatchRepository(GamesDbContext db, IMapper mapper)
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

        private IQueryable<Stadium> AllStadiums()
            => this
                .Data
                .Stadiums
                .AsNoTracking();
    }
}
