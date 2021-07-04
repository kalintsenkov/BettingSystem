﻿namespace BettingSystem.Application.Matches.Matches
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Contracts;
    using Domain.Common;
    using Domain.Matches.Models.Matches;
    using Queries.Common;
    using Queries.Details;
    using Queries.Stadiums;

    public interface IMatchQueryRepository : IQueryRepository<Match>
    {
        Task<IEnumerable<MatchResponseModel>> GetMatchListings(
            Specification<Match> matchSpecification,
            CancellationToken cancellationToken = default);

        Task<MatchDetailsResponseModel> GetDetails(
            int id,
            CancellationToken cancellationToken = default);

        Task<IEnumerable<GetMatchStadiumsResponseModel>> GetStadiums(
            CancellationToken cancellationToken = default);
    }
}