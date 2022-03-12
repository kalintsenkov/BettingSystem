namespace BettingSystem.Application.Competitions.Leagues.Queries.Countries;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class GetCountriesQuery : IRequest<IEnumerable<GetCountriesResponseModel>>
{
    public class GetCountriesQueryHandler : IRequestHandler<
        GetCountriesQuery,
        IEnumerable<GetCountriesResponseModel>>
    {
        private readonly ILeagueQueryRepository leaguesRepository;

        public GetCountriesQueryHandler(ILeagueQueryRepository leaguesRepository) 
            => this.leaguesRepository = leaguesRepository;

        public async Task<IEnumerable<GetCountriesResponseModel>> Handle(
            GetCountriesQuery request,
            CancellationToken cancellationToken)
            => await this.leaguesRepository.GetCountriesListing(cancellationToken);
    }
}