namespace BettingSystem.Application.Features.Bets.Queries.Mine
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Contracts;
    using Gamblers;
    using MediatR;

    public class MineBetsQuery : BetsQuery, IRequest<MineBetsResponseModel>
    {
        public class MineBetsQueryHandler : BetsQueryHandler, IRequestHandler<
            MineBetsQuery,
            MineBetsResponseModel>
        {
            private readonly ICurrentUser currentUser;
            private readonly IGamblerRepository gamblerRepository;

            public MineBetsQueryHandler(
                ICurrentUser currentUser,
                IBetRepository betRepository,
                IGamblerRepository gamblerRepository)
                : base(betRepository)
            {
                this.currentUser = currentUser;
                this.gamblerRepository = gamblerRepository;
            }

            public async Task<MineBetsResponseModel> Handle(
                MineBetsQuery request,
                CancellationToken cancellationToken)
            {
                var gamblerId = await this.gamblerRepository.GetGamblerId(
                    this.currentUser.UserId,
                    cancellationToken);

                var betListings = await base.GetBetListings<MineBetResponseModel>(
                    request,
                    gamblerId,
                    cancellationToken);

                return new MineBetsResponseModel(betListings);
            }
        }
    }
}
