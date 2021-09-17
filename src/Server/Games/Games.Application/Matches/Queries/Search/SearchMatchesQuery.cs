namespace BettingSystem.Application.Games.Matches.Queries.Search
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Common;
    using Domain.Games.Models.Matches;
    using Domain.Games.Specifications;
    using MediatR;

    public class SearchMatchesQuery : IRequest<SearchMatchesResponseModel>
    {
        public string? StartDate { get; set; }

        public string? HomeTeam { get; set; }

        public string? AwayTeam { get; set; }

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
                => new MatchByStartDateSpecification(request.StartDate)
                    .And(new MatchByHomeTeamSpecification(request.HomeTeam))
                    .And(new MatchByAwayTeamSpecification(request.AwayTeam));
        }
    }
}
