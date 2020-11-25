namespace BettingSystem.Application.Features.Bets.Commands.Close
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Contracts;
    using Domain.Models.Matches;
    using Gamblers;
    using MediatR;

    public class CloseBetCommand : EntityCommand<int>, IRequest<Result>
    {
        public class CloseBetCommandHandler : IRequestHandler<CloseBetCommand, Result>
        {
            private const string InvalidErrorMessage = "You cannot close this bet.";

            private readonly ICurrentUser currentUser;
            private readonly IBetRepository betRepository;
            private readonly IGamblerRepository gamblerRepository;

            public CloseBetCommandHandler(
                ICurrentUser currentUser,
                IBetRepository betRepository,
                IGamblerRepository gamblerRepository)
            {
                this.currentUser = currentUser;
                this.betRepository = betRepository;
                this.gamblerRepository = gamblerRepository;
            }

            public async Task<Result> Handle(
                CloseBetCommand request,
                CancellationToken cancellationToken)
            {
                var gamblerId = await this.gamblerRepository.GetGamblerId(
                    this.currentUser.UserId,
                    cancellationToken);

                var gamblerHasBet = await this.gamblerRepository.HasBet(
                    gamblerId,
                    request.Id,
                    cancellationToken);

                if (!gamblerHasBet)
                {
                    return InvalidErrorMessage;
                }

                var bet = await this.betRepository.Find(
                    request.Id,
                    cancellationToken);

                var matchStatus = bet.Match.Status;

                if (matchStatus == Status.InPlay ||
                    matchStatus == Status.Finished)
                {
                    return InvalidErrorMessage;
                }

                return await this.betRepository.Delete(
                    request.Id,
                    cancellationToken);
            }
        }
    }
}
