namespace BettingSystem.Application.Competitions.Leagues.Queries.All;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class GetAllLeaguesQuery : IRequest<IEnumerable<GetAllLeaguesResponseModel>>
{
    public class GetAllLeaguesQueryHandler : IRequestHandler<
        GetAllLeaguesQuery,
        IEnumerable<GetAllLeaguesResponseModel>>
    {
        private readonly ILeagueQueryRepository leagueRepository;

        public GetAllLeaguesQueryHandler(ILeagueQueryRepository leagueRepository)
            => this.leagueRepository = leagueRepository;

        public async Task<IEnumerable<GetAllLeaguesResponseModel>> Handle(
            GetAllLeaguesQuery request,
            CancellationToken cancellationToken)
            => await this.leagueRepository.GetLeaguesListing(cancellationToken);
    }
}