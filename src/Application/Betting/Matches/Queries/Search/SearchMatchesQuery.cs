namespace BettingSystem.Application.Betting.Matches.Queries.Search
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Betting.Models.Matches;
    using Domain.Betting.Specifications.Matches;
    using Domain.Common;
    using MediatR;

    public class SearchMatchesQuery : IRequest<SearchMatchesResponseModel>
    {
        public string? HomeTeam { get; set; }

        public string? AwayTeam { get; set; }

        public string? Stadium { get; set; }

        public class SearchMatchesQueryHandler : IRequestHandler<SearchMatchesQuery, SearchMatchesResponseModel>
        {
            private readonly IMatchQueryRepository matchRepository;

            public SearchMatchesQueryHandler(IMatchQueryRepository matchRepository)
                => this.matchRepository = matchRepository;

            public async Task<SearchMatchesResponseModel> Handle(
                SearchMatchesQuery request,
                CancellationToken cancellationToken)
            {
                var matchSpecification = this.GetMatchSpecification(request);

                var matchListings = await this.matchRepository.GetMatchListings(
                    matchSpecification,
                    cancellationToken);

                return new SearchMatchesResponseModel(matchListings);
            }

            private Specification<Match> GetMatchSpecification(
                SearchMatchesQuery request)
                => new MatchByHomeTeamSpecification(request.HomeTeam)
                    .And(new MatchByAwayTeamSpecification(request.AwayTeam))
                    .And(new MatchByStadiumSpecification(request.Stadium));
        }
    }
}
