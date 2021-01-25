namespace BettingSystem.Application.Competitions.Matches.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Exceptions;
    using Common;
    using Domain.Competitions.Factories.Matches;
    using Domain.Competitions.Repositories;
    using MediatR;

    public class CreateMatchCommand : MatchCommand<CreateMatchCommand>, IRequest<CreateMatchResponseModel>
    {
        public class CreateMatchCommandHandler : IRequestHandler<CreateMatchCommand, CreateMatchResponseModel>
        {
            private readonly IMatchFactory matchFactory;
            private readonly IMatchDomainRepository matchRepository;

            public CreateMatchCommandHandler(
                IMatchFactory matchFactory,
                IMatchDomainRepository matchRepository)
            {
                this.matchFactory = matchFactory;
                this.matchRepository = matchRepository;
            }

            public async Task<CreateMatchResponseModel> Handle(
                CreateMatchCommand request,
                CancellationToken cancellationToken)
            {
                var homeTeam = await this.matchRepository.GetTeam(
                    request.HomeTeam,
                    cancellationToken);

                if (homeTeam == null)
                {
                    throw new NotFoundException(nameof(homeTeam), request.HomeTeam);
                }

                var awayTeam = await this.matchRepository.GetTeam(
                    request.AwayTeam,
                    cancellationToken);

                if (awayTeam == null)
                {
                    throw new NotFoundException(nameof(awayTeam), request.AwayTeam);
                }

                var stadium = await this.matchRepository.GetStadium(
                    request.StadiumName,
                    cancellationToken);

                var factory = stadium == null
                    ? this.matchFactory.WithStadium(request.StadiumName, request.StadiumImageUrl)
                    : this.matchFactory.WithStadium(stadium);

                var match = factory
                    .WithStartDate(request.StartDate)
                    .WithHomeTeam(homeTeam)
                    .WithAwayTeam(awayTeam)
                    .Build();

                await this.matchRepository.Save(match, cancellationToken);

                return new CreateMatchResponseModel(match.Id);
            }
        }
    }
}
