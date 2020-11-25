namespace BettingSystem.Application.Features.Bets.Commands.MakeProfitable
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Exceptions;
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

                if (bet == null)
                {
                    throw new NotFoundException(nameof(bet), request.Id);
                }

                bet.MakeProfitable();

                await this.betRepository.Save(bet, cancellationToken);

                return Result.Success;
            }
        }
    }
}
