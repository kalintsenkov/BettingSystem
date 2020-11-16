namespace BettingSystem.Application.Features.Matches.Commands.Create
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Factories.Matches;
    using MediatR;

    public class CreateMatchCommand : IRequest<CreateMatchResponseModel>
    {
        public DateTime StartDate { get; set; }

        public string HomeTeam { get; set; } = default!;

        public string AwayTeam { get; set; } = default!;

        public string StadiumName { get; set; } = default!;

        public string StadiumImageUrl { get; set; } = default!;

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
                    ? this.matchFactory.WithAwayTeam(request.AwayTeam)
                    : this.matchFactory.WithAwayTeam(awayTeam);

                factory = stadium == null
                    ? this.matchFactory.WithStadium(request.StadiumName, request.StadiumImageUrl)
                    : this.matchFactory.WithStadium(stadium);

                var match = factory
                    .WithStartDate(request.StartDate)
                    .Build();

                await this.matchRepository.Save(
                    match,
                    cancellationToken);

                return new CreateMatchResponseModel(match.Id);
            }
        }
    }
}
