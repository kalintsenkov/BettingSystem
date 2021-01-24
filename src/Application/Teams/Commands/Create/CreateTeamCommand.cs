namespace BettingSystem.Application.Teams.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Domain.Teams.Factories;
    using Domain.Teams.Repositories;
    using MediatR;

    public class CreateTeamCommand : TeamCommand<CreateTeamCommand>, IRequest<CreateTeamResponseModel>
    {
        public int LeagueId { get; set; }

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
                    .InLeague(request.LeagueId)
                    .Build();

                await this.teamRepository.Save(team, cancellationToken);

                return new CreateTeamResponseModel(team.Id);
            }
        }
    }
}
