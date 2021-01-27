namespace BettingSystem.Application.Competitions.Matches.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common;
    using Application.Common.Contracts;
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
            private readonly IImageService imageService;

            public CreateMatchCommandHandler(
                IMatchFactory matchFactory,
                IMatchDomainRepository matchRepository,
                IImageService imageService)
            {
                this.matchFactory = matchFactory;
                this.matchRepository = matchRepository;
                this.imageService = imageService;
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

                var factory = this.matchFactory.WithStartDate(request.StartDate);

                if (stadium == null)
                {
                    var (original, thumbnail) = await this.imageService.Process(
                        new ImageCommand(
                            request.StadiumImage.OpenReadStream()));

                    factory = factory.WithStadium(request.StadiumName, original, thumbnail);
                }
                else
                {
                    factory = factory.WithStadium(stadium);
                }

                var match = factory
                    .WithHomeTeam(homeTeam)
                    .WithAwayTeam(awayTeam)
                    .Build();

                await this.matchRepository.Save(match, cancellationToken);

                return new CreateMatchResponseModel(match.Id);
            }
        }
    }
}
