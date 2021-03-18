namespace BettingSystem.Application.Competitions.Teams.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Domain.Competitions.Factories.Teams;
    using Domain.Competitions.Repositories;
    using MediatR;

    public class CreateTeamCommand : EntityCommand<int>, IRequest<CreateTeamResponseModel>
    {
        public string Name { get; set; } = default!;

        public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, CreateTeamResponseModel>
        {
            private readonly ITeamFactory teamFactory;
            private readonly ITeamDomainRepository teamRepository;

            public CreateTeamCommandHandler(
                ITeamFactory teamFactory,
                ITeamDomainRepository teamRepository)
            {
                this.teamFactory = teamFactory;
                this.teamRepository = teamRepository;
            }

            public async Task<CreateTeamResponseModel> Handle(
                CreateTeamCommand request,
                CancellationToken cancellationToken)
            {
                var team = this.teamFactory
                    .WithName(request.Name)
                    .Build();

                await this.teamRepository.Save(team, cancellationToken);

                return new CreateTeamResponseModel(team.Id);
            }
        }
    }
}
