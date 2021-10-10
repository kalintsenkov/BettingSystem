namespace BettingSystem.Infrastructure.Competitions.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Competitions.Leagues;
    using Application.Competitions.Leagues.Queries.All;
    using Application.Competitions.Leagues.Queries.Countries;
    using Application.Competitions.Leagues.Queries.Standings;
    using AutoMapper;
    using Common.Repositories;
    using Domain.Competitions.Models.Leagues;
    using Domain.Competitions.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Persistence;

    internal class LeagueRepository : DataRepository<CompetitionsDbContext, League>,
        ILeagueDomainRepository,
        ILeagueQueryRepository
    {
        private readonly IMapper mapper;

        public LeagueRepository(CompetitionsDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<bool> Delete(
            int id,
            CancellationToken cancellationToken = default)
        {
            var league = await this.Data.Leagues.FindAsync(id);

            if (league == null)
            {
                return false;
            }

            this.Data.Leagues.Remove(league);

            await this.Data.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<League> Find(
            int id,
            CancellationToken cancellationToken = default)
            => await this
                .All()
                .Where(l => l.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<Country> GetCountry(
            string country,
            CancellationToken cancellationToken = default)
            => await this
                .AllCountries()
                .FirstOrDefaultAsync(s => s.Name == country, cancellationToken);

        public async Task<IEnumerable<GetAllLeaguesResponseModel>> GetLeagueListings(
            CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<GetAllLeaguesResponseModel>(this
                    .AllAsNoTracking())
                .ToListAsync(cancellationToken);

        public async Task<IEnumerable<GetCountriesResponseModel>> GetCountries(
            CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<GetCountriesResponseModel>(this
                    .AllCountries())
                .ToListAsync(cancellationToken);

        public async Task<IEnumerable<GetStandingsResponseModel>> GetStandings(
            int leagueId,
            CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<GetStandingsResponseModel>(this
                    .AllAsNoTracking()
                    .Where(l => l.Id == leagueId)
                    .SelectMany(l => l.Teams)
                    .OrderByDescending(t => t.Points))
                .ToListAsync(cancellationToken);

        private IQueryable<Country> AllCountries()
            => this
                .Data
                .Countries
                .AsNoTracking();
    }
}
