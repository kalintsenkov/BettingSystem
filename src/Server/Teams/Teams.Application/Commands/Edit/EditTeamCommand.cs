namespace BettingSystem.Application.Teams.Commands.Edit;

using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Contracts;
using Application.Common.Exceptions;
using Common;
using Domain.Teams.Repositories;
using MediatR;

public class EditTeamCommand : TeamCommand<EditTeamCommand>, IRequest<Result>
{
    public class EditTeamCommandHandler : IRequestHandler<EditTeamCommand, Result>
    {
        private readonly IImageService imageService;
        private readonly ITeamDomainRepository teamRepository;

        public EditTeamCommandHandler(
            IImageService imageService,
            ITeamDomainRepository teamRepository)
        {
            this.imageService = imageService;
            this.teamRepository = teamRepository;
        }

        public async Task<Result> Handle(
            EditTeamCommand request,
            CancellationToken cancellationToken)
        {
            var team = await this.teamRepository.Find(
                request.Id,
                cancellationToken);

            if (team == null)
            {
                throw new NotFoundException(nameof(team), request.Id);
            }

            var coach = await this.teamRepository.GetCoach(
                request.Coach,
                cancellationToken);

            if (coach == null)
            {
                throw new NotFoundException(nameof(coach), request.Coach);
            }

            var logo = await this.imageService.Process(request.Logo);

            team
                .UpdateName(request.Name)
                .UpdateLogo(
                    logo.OriginalContent,
                    logo.ThumbnailContent)
                .UpdateCoach(coach);

            await this.teamRepository.Save(team, cancellationToken);

            return Result.Success;
        }
    }
}