namespace BettingSystem.Application.Teams.Commands.Edit
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common;
    using Application.Common.Contracts;
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

                var logo = await this.imageService.Process(request.Logo);

                team
                    .UpdateName(request.Name)
                    .UpdateLogo(
                        logo.OriginalContent,
                        logo.ThumbnailContent);

                await this.teamRepository.Save(team, cancellationToken);

                return Result.Success;
            }
        }
    }
}
