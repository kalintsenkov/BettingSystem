namespace BettingSystem.Application.Competitions.Leagues;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Contracts;
using Domain.Competitions.Models.Leagues;
using Queries.All;
using Queries.Countries;
using Queries.Standings;

public interface ILeagueQueryRepository : IQueryRepository<League>
{
    Task<IEnumerable<GetAllLeaguesResponseModel>> GetLeaguesListing(
        CancellationToken cancellationToken = default);

    Task<IEnumerable<GetCountriesResponseModel>> GetCountriesListing(
        CancellationToken cancellationToken = default);

    Task<IEnumerable<GetStandingsResponseModel>> GetStandings(
        int leagueId,
        CancellationToken cancellationToken = default);
}