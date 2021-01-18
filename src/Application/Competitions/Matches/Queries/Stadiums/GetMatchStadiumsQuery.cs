namespace BettingSystem.Application.Competitions.Matches.Queries.Stadiums
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class GetMatchStadiumsQuery : IRequest<IEnumerable<GetMatchStadiumsResponseModel>>
    {
        public class GetMatchStadiumsQueryHandler : IRequestHandler<
            GetMatchStadiumsQuery,
            IEnumerable<GetMatchStadiumsResponseModel>>
        {
            private readonly IMatchQueryRepository matchRepository;

            public GetMatchStadiumsQueryHandler(IMatchQueryRepository matchRepository)
                => this.matchRepository = matchRepository;

            public async Task<IEnumerable<GetMatchStadiumsResponseModel>> Handle(
                GetMatchStadiumsQuery request,
                CancellationToken cancellationToken)
                => await this.matchRepository.GetStadiums(cancellationToken);
        }
    }
}
