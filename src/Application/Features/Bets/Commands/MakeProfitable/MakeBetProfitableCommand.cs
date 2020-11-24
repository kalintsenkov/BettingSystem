namespace BettingSystem.Application.Features.Bets.Commands.MakeProfitable
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using MediatR;

    public class MakeBetProfitableCommand : EntityCommand<int, MakeBetProfitableCommand>, IRequest<Result>
    {
        public class MakeBetProfitableCommandHandler : IRequestHandler<MakeBetProfitableCommand, Result>
        {
            private readonly IBetRepository betRepository;

            public MakeBetProfitableCommandHandler(IBetRepository betRepository) 
                => this.betRepository = betRepository;

            public async Task<Result> Handle(
                MakeBetProfitableCommand request,
                CancellationToken cancellationToken)
            {
                var bet = await this.betRepository.Find(
                    request.Id,
                    cancellationToken);

                // TODO: Match validation (result and prediction)

                bet.MakeProfitable();

                await this.betRepository.Save(bet, cancellationToken);

                return Result.Success;
            }
        }
    }
}
