namespace BettingSystem.Application.Features.Matches.Queries.Details
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class MatchDetailsQuery : IRequest<MatchDetailsResponseModel>
    {
        public int Id { get; set; }

        public class MatchDetailsQueryHandler : IRequestHandler<MatchDetailsQuery, MatchDetailsResponseModel>
        {
            private readonly IMatchRepository matchRepository;

            public MatchDetailsQueryHandler(IMatchRepository matchRepository)
                => this.matchRepository = matchRepository;

            public async Task<MatchDetailsResponseModel> Handle(
                MatchDetailsQuery request,
                CancellationToken cancellationToken)
                => await this.matchRepository.GetDetails(
                    request.Id,
                    cancellationToken);
        }
    }
}
