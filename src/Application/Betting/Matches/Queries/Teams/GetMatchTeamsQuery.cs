namespace BettingSystem.Application.Betting.Matches.Queries.Teams
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class GetMatchTeamsQuery : IRequest<IEnumerable<GetMatchTeamsResponseModel>>
    {
        public class GetMatchTeamsQueryHandler : IRequestHandler<
            GetMatchTeamsQuery,
            IEnumerable<GetMatchTeamsResponseModel>>
        {
            private readonly IMatchQueryRepository matchRepository;

            public GetMatchTeamsQueryHandler(IMatchQueryRepository matchRepository)
                => this.matchRepository = matchRepository;

            public async Task<IEnumerable<GetMatchTeamsResponseModel>> Handle(
                GetMatchTeamsQuery request,
                CancellationToken cancellationToken)
                => await this.matchRepository.GetTeams(cancellationToken);
        }
    }
}
