namespace BettingSystem.Application.Features.Matches
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Contracts;
    using Domain.Models.Matches;
    using Domain.Models.Teams;
    using Domain.Specifications;
    using Queries.Common;
    using Queries.Details;
    using Queries.Stadiums;

    public interface IMatchRepository : IRepository<Match>
    {
        Task<bool> Delete(
            int id,
            CancellationToken cancellationToken = default);

        Task<Match> Find(
            int id,
            CancellationToken cancellationToken = default);

        Task<IEnumerable<MatchResponseModel>> GetMatchListings(
            Specification<Match> matchSpecification,
            CancellationToken cancellationToken = default);

        Task<MatchDetailsResponseModel> GetDetails(
            int id,
            CancellationToken cancellationToken = default);

        Task<Team> GetHomeTeam(
            string homeTeam,
            CancellationToken cancellationToken = default);

        Task<Team> GetAwayTeam(
            string awayTeam,
            CancellationToken cancellationToken = default);

        Task<Stadium> GetStadium(
            string stadium,
            CancellationToken cancellationToken = default);

        Task<IEnumerable<GetMatchStadiumsResponseModel>> GetStadiums(
            CancellationToken cancellationToken = default);
    }
}