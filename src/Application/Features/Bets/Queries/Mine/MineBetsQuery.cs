namespace BettingSystem.Application.Features.Bets.Queries.Mine
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Contracts;
    using Gamblers;
    using MediatR;

    public class MineBetsQuery : IRequest<IEnumerable<MineBetsResponseModel>>
    {
        public class MineBetsQueryHandler : IRequestHandler<MineBetsQuery, IEnumerable<MineBetsResponseModel>>
        {
            private readonly ICurrentUser currentUser;
            private readonly IBetRepository betRepository;
            private readonly IGamblerRepository gamblerRepository;

            public MineBetsQueryHandler(
                ICurrentUser currentUser,
                IBetRepository betRepository,
                IGamblerRepository gamblerRepository)
            {
                this.currentUser = currentUser;
                this.betRepository = betRepository;
                this.gamblerRepository = gamblerRepository;
            }

            public async Task<IEnumerable<MineBetsResponseModel>> Handle(
                MineBetsQuery request,
                CancellationToken cancellationToken)
            {
                var gamblerId = await this.gamblerRepository.GetGamblerId(
                    this.currentUser.UserId,
                    cancellationToken);

                return await this.betRepository.GetMine(
                    gamblerId,
                    cancellationToken);
            }
        }
    }
}
