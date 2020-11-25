namespace BettingSystem.Application.Features.Matches.Queries.Search
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Models.Matches;
    using Domain.Specifications;
    using Domain.Specifications.Matches;
    using MediatR;

    public class SearchMatchesQuery : IRequest<SearchMatchesResponseModel>
    {
        public string? HomeTeam { get; set; }

        public string? AwayTeam { get; set; }

        public string? Stadium { get; set; }

        public class SearchMatchesQueryHandler : IRequestHandler<SearchMatchesQuery, SearchMatchesResponseModel>
        {
            private readonly IMatchRepository matchRepository;

            public SearchMatchesQueryHandler(IMatchRepository matchRepository)
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
