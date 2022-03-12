namespace BettingSystem.Application.Games.Matches.Commands.Create;

using System.Threading;
using System.Threading.Tasks;
using Application.Common.Contracts;
using Application.Common.Exceptions;
using Common;
using Domain.Games.Factories.Matches;
using Domain.Games.Repositories;
using MediatR;

public class CreateMatchCommand : MatchCommand<CreateMatchCommand>, IRequest<CreateMatchResponseModel>
{
    public class CreateMatchCommandHandler : IRequestHandler<CreateMatchCommand, CreateMatchResponseModel>
    {
        private readonly IMatchFactory matchFactory;
        private readonly IMatchDomainRepository matchRepository;
        private readonly ITeamDomainRepository teamRepository;
        private readonly IImageService imageService;

        public CreateMatchCommandHandler(
            IMatchFactory matchFactory,
            IMatchDomainRepository matchRepository,
            ITeamDomainRepository teamRepository,
            IImageService imageService)
        {
            this.matchFactory = matchFactory;
            this.matchRepository = matchRepository;
            this.teamRepository = teamRepository;
            this.imageService = imageService;
        }

        public async Task<CreateMatchResponseModel> Handle(
            CreateMatchCommand request,
            CancellationToken cancellationToken)
        {
            var homeTeam = await this.teamRepository.Find(
                request.HomeTeam,
                cancellationToken);

            if (homeTeam == null)
            {
                throw new NotFoundException(nameof(homeTeam), request.HomeTeam);
            }

            var awayTeam = await this.teamRepository.Find(
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
                var image = await this.imageService.Process(request.StadiumImage);

                factory = factory.WithStadium(
                    request.StadiumName, 
                    image.OriginalContent, 
                    image.ThumbnailContent);
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