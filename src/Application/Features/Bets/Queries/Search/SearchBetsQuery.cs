namespace BettingSystem.Application.Features.Bets.Queries.Search
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using MediatR;

    public class SearchBetsQuery : BetsQuery, IRequest<SearchBetsResponseModel>
    {
        public class SearchBetsQueryHandler : BetsQueryHandler, IRequestHandler<
            SearchBetsQuery,
            SearchBetsResponseModel>
        {
            public SearchBetsQueryHandler(IBetRepository betRepository)
                : base(betRepository)
            {
            }

            public async Task<SearchBetsResponseModel> Handle(
                SearchBetsQuery request,
                CancellationToken cancellationToken)
            {
                var betListings = await base.GetBetListings<BetResponseModel>(
                    request,
                    cancellationToken: cancellationToken);

                return new SearchBetsResponseModel(betListings);
            }
        }
    }
}
