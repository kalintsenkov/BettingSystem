namespace BettingSystem.Application.Features.Matches.Queries.Teams
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
            private readonly IMatchRepository matchRepository;

            public GetMatchTeamsQueryHandler(IMatchRepository matchRepository)
                => this.matchRepository = matchRepository;

            public async Task<IEnumerable<GetMatchTeamsResponseModel>> Handle(
                GetMatchTeamsQuery request,
                CancellationToken cancellationToken)
                => await this.matchRepository.GetTeams(cancellationToken);
        }
    }
}
