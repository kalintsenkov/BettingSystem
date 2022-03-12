namespace BettingSystem.Application.Competitions.Leagues.Queries.Standings;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class GetStandingsQuery : IRequest<IEnumerable<GetStandingsResponseModel>>
{
    public int Id { get; set; }

    public class GetStandingsQueryHandler : IRequestHandler<
        GetStandingsQuery,
        IEnumerable<GetStandingsResponseModel>>
    {
        private readonly ILeagueQueryRepository leagueRepository;

        public GetStandingsQueryHandler(ILeagueQueryRepository leagueRepository)
            => this.leagueRepository = leagueRepository;

        public async Task<IEnumerable<GetStandingsResponseModel>> Handle(
            GetStandingsQuery request,
            CancellationToken cancellationToken)
            => await this.leagueRepository.GetStandings(
                request.Id,
                cancellationToken);
    }
}