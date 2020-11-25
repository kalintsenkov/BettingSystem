namespace BettingSystem.Application.Features.Matches.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Domain.Factories.Matches;
    using MediatR;

    public class CreateMatchCommand : MatchCommand<CreateMatchCommand>, IRequest<CreateMatchResponseModel>
    {
        public class CreateMatchCommandHandler : IRequestHandler<CreateMatchCommand, CreateMatchResponseModel>
        {
            private readonly IMatchFactory matchFactory;
            private readonly IMatchRepository matchRepository;

            public CreateMatchCommandHandler(
                IMatchFactory matchFactory,
                IMatchRepository matchRepository)
            {
                this.matchFactory = matchFactory;
                this.matchRepository = matchRepository;
            }

            public async Task<CreateMatchResponseModel> Handle(
                CreateMatchCommand request,
                CancellationToken cancellationToken)
            {
                var homeTeam = await this.matchRepository.GetHomeTeam(
                    request.HomeTeam,
                    cancellationToken);

                var awayTeam = await this.matchRepository.GetAwayTeam(
                    request.AwayTeam,
                    cancellationToken);

                var stadium = await this.matchRepository.GetStadium(
                    request.StadiumName,
                    cancellationToken);

                var factory = homeTeam == null
                    ? this.matchFactory.WithHomeTeam(request.HomeTeam)
                    : this.matchFactory.WithHomeTeam(homeTeam);

                factory = awayTeam == null
                    ? factory.WithAwayTeam(request.AwayTeam)
                    : factory.WithAwayTeam(awayTeam);

                factory = stadium == null
                    ? factory.WithStadium(request.StadiumName, request.StadiumImageUrl)
                    : factory.WithStadium(stadium);

                var match = factory
                    .WithStartDate(request.StartDate)
                    .Build();

                await this.matchRepository.Save(match, cancellationToken);

                return new CreateMatchResponseModel(match.Id);
            }
        }
    }
}
