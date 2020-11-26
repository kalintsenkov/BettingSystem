namespace BettingSystem.Application.Features.Bets.Queries.Common
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Models.Bets;
    using Domain.Models.Gamblers;
    using Domain.Specifications;
    using Domain.Specifications.Bets;
    using Domain.Specifications.Gamblers;

    public abstract class BetsQuery
    {
        public bool? OnlyProfitable { get; set; }

        public abstract class BetsQueryHandler
        {
            private readonly IBetRepository betRepository;

            protected BetsQueryHandler(IBetRepository betRepository)
                => this.betRepository = betRepository;

            protected async Task<IEnumerable<TResponseModel>> GetBetListings<TResponseModel>(
                BetsQuery request,
                int? gamblerId = default,
                CancellationToken cancellationToken = default)
            {
                var betSpecification = this.GetBetSpecification(request);

                var gamblerSpecification = this.GetGamblerSpecification(gamblerId);

                return await this.betRepository.GetBetListings<TResponseModel>(
                    betSpecification,
                    gamblerSpecification,
                    cancellationToken);
            }

            private Specification<Bet> GetBetSpecification(BetsQuery request)
                => new BetOnlyProfitableSpecification(request.OnlyProfitable);

            private Specification<Gambler> GetGamblerSpecification(int? gamblerId)
                => new GamblerByIdSpecification(gamblerId);
        }
    }
}
