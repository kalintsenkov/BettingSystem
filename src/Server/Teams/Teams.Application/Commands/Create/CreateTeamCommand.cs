namespace BettingSystem.Application.Teams.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Contracts;
    using Common;
    using Domain.Teams.Factories;
    using Domain.Teams.Repositories;
    using MediatR;

    public class CreateTeamCommand : TeamCommand<CreateTeamCommand>, IRequest<CreateTeamResponseModel>
    {
        public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, CreateTeamResponseModel>
        {
            private readonly IImageService imageService;
            private readonly ITeamFactory teamFactory;
            private readonly ITeamDomainRepository teamRepository;

            public CreateTeamCommandHandler(
                IImageService imageService,
                ITeamFactory teamFactory,
                ITeamDomainRepository teamRepository)
            {
                this.imageService = imageService;
                this.teamFactory = teamFactory;
                this.teamRepository = teamRepository;
            }

            public async Task<CreateTeamResponseModel> Handle(
                CreateTeamCommand request,
                CancellationToken cancellationToken)
            {
                var logo = await this.imageService.Process(request.Logo);

                var coach = await this.teamRepository.GetCoach(
                    request.Coach,
                    cancellationToken);

                var factory = this.teamFactory
                    .WithName(request.Name)
                    .WithLogo(
                        logo.OriginalContent,
                        logo.ThumbnailContent);

                factory = coach != null
                    ? factory.WithCoach(coach)
                    : factory.WithCoach(request.Coach);

                var team = factory.Build();

                await this.teamRepository.Save(team, cancellationToken);

                return new CreateTeamResponseModel(team.Id);
            }
        }
    }
}
