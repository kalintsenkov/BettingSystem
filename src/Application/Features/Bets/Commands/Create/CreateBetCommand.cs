namespace BettingSystem.Application.Features.Bets.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Contracts;
    using Domain.Common;
    using Domain.Factories.Bets;
    using Domain.Models.Bets;
    using Exceptions;
    using Gamblers;
    using Matches;
    using MediatR;

    public class CreateBetCommand : IRequest<CreateBetResponseModel>
    {
        public int MatchId { get; set; }

        public decimal Amount { get; set; }

        public int Prediction { get; set; }

        public class CreateBetCommandHandler : IRequestHandler<CreateBetCommand, CreateBetResponseModel>
        {
            private readonly ICurrentUser currentUser;
            private readonly IBetFactory betFactory;
            private readonly IBetRepository betRepository;
            private readonly IMatchRepository matchRepository;
            private readonly IGamblerRepository gamblerRepository;

            public CreateBetCommandHandler(
                ICurrentUser currentUser,
                IBetFactory betFactory,
                IBetRepository betRepository,
                IMatchRepository matchRepository,
                IGamblerRepository gamblerRepository)
            {
                this.currentUser = currentUser;
                this.betFactory = betFactory;
                this.betRepository = betRepository;
                this.matchRepository = matchRepository;
                this.gamblerRepository = gamblerRepository;
            }

            public async Task<CreateBetResponseModel> Handle(
                CreateBetCommand request,
                CancellationToken cancellationToken)
            {
                var gambler = await this.gamblerRepository.FindByUser(
                    this.currentUser.UserId,
                    cancellationToken);

                var match = await this.matchRepository.Find(
                    request.MatchId,
                    cancellationToken);

                if (match == null)
                {
                    throw new NotFoundException(nameof(match), request.MatchId);
                }

                var bet = this.betFactory
                    .WithMatch(match)
                    .WithAmount(request.Amount)
                    .WithPrediction(Enumeration.FromValue<Prediction>(
                        request.Prediction))
                    .Build();

                gambler.AddBet(bet);

                await this.betRepository.Save(bet, cancellationToken);

                return new CreateBetResponseModel(bet.Id);
            }
        }
    }
}
