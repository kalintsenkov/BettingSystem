namespace BettingSystem.Application.Competitions.Leagues.Queries.Standings
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class LeagueStandingsQuery : IRequest<IEnumerable<LeagueStandingsResponseModel>>
    {
        public int Id { get; set; }

        public class LeagueStandingsQueryHandler : IRequestHandler<
            LeagueStandingsQuery,
            IEnumerable<LeagueStandingsResponseModel>>
        {
            private readonly ILeagueQueryRepository leagueRepository;

            public LeagueStandingsQueryHandler(ILeagueQueryRepository leagueRepository)
                => this.leagueRepository = leagueRepository;

            public async Task<IEnumerable<LeagueStandingsResponseModel>> Handle(
                LeagueStandingsQuery request,
                CancellationToken cancellationToken)
                => await this.leagueRepository.GetStandings(
                    request.Id,
                    cancellationToken);
        }
    }
}
